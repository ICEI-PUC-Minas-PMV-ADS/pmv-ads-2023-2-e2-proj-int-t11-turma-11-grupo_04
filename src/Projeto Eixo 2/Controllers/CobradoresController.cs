using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Eixo_2.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Projeto_Eixo_2.Controllers
{
    [Authorize]
    public class CobradoresController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IEmailService _emailService;

        public CobradoresController(AppDbContext context, IWebHostEnvironment env, IEmailService emailService)
        {
            _context = context;
            _env = env;
            _emailService = emailService;
        }

        [Authorize(Roles = "Admin")]
        // GET: Cobradores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cobradores.ToListAsync());
        }
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Cobrador cobrador)
        {
            var dados = await _context.Cobradores.FirstOrDefaultAsync(c => c.Email == cobrador.Email);

            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou senha incorretos";
                return View();
            }

            bool senhaOk = BCrypt.Net.BCrypt.Verify(cobrador.Senha, dados.Senha);

            if (senhaOk)
            {
                var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, dados.NomeCobrador),
                     new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                     new Claim(ClaimTypes.Role, dados.Perfil.ToString())
                };

                var cobradorIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(cobradorIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha incorretos";
            }

            return View();
        }

        [AllowAnonymous]
        // GET: Cobradores/Create
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Cobradores");
        }
        // GET: Cobradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobradores == null)
            {
                return NotFound();
            }

            var cobrador = await _context.Cobradores.FirstOrDefaultAsync(m => m.Id == id);

            if (cobrador == null)
            {
                return NotFound();
            }

            // Encontre todos os clientes associados a esse cobrador usando a chave estrangeira
            var clientesDoCobrador = await _context.Clientes
                                            .Where(c => c.CobradorId == cobrador.Id)
                                            .ToListAsync();
            ViewBag.ClientesDoCobrador = clientesDoCobrador; // Passe os clientes para a view usando ViewBag

            var cobrancasDoCobrador = await _context.Cobranca
                                            .Where(c => c.CobradorId == cobrador.Id)
                                            .ToListAsync();
            ViewBag.CobrancasDoCobrador = cobrancasDoCobrador;

            return View(cobrador);
        }

        // POST: Cobradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public async Task<IActionResult> Create([Bind("Id,NomeCobrador,SobrenomeCobrador,CPF,Email,CEP,Endereco,Bairro,Cidade,UF,Telefone,Senha,Perfil, FotoArquivo")] Cobrador cobrador)
        {
            if (ModelState.IsValid)
            {
                // Verifica o tamanho mínimo da senha
                if (cobrador.Senha.Length < 6)
                {
                    ModelState.AddModelError("Senha", "A senha deve ter no mínimo 6 caracteres.");
                    return View(cobrador);
                }

                // Retira o ponto e o tracinho do CPF antes de validar
                cobrador.CPF = cobrador.CPF.Replace(".", "").Replace("-", "");

                // Verifica se o CPF tem 11 dígitos e se tem apenas números

                if (cobrador.CPF.Length != 11 || !cobrador.CPF.All(char.IsDigit))
                {
                    ModelState.AddModelError("CPF", "O CPF deve ter exatamente 11 dígitos e conter apenas números.");
                    return View(cobrador);
                }

                // Retira o tracinho do CEP antes de validar
                cobrador.CEP = cobrador.CEP.Replace("-", "");
                // Verifica o formato do CEP
                if (cobrador.CEP.Length != 8 || !cobrador.CEP.All(char.IsDigit))
                {
                    ModelState.AddModelError("CEP", "O CEP deve ter exatamente 8 dígitos e conter apenas números.");
                    return View(cobrador);
                }

                // Verifica se telefone tem apenas dígitos
                if (!cobrador.Telefone.All(char.IsDigit))
                {
                    ModelState.AddModelError("Telefone", "O telefone deve conter apenas números.");
                    return View(cobrador);
                }

                if (cobrador.FotoArquivo != null && cobrador.FotoArquivo.Length > 0)
                {
                    // Gere um nome único para o arquivo para evitar conflitos
                    var nomeArquivo = Guid.NewGuid().ToString() + "_" + Path.GetFileName(cobrador.FotoArquivo.FileName);

                    // Caminho do diretório onde o arquivo será salvo na pasta wwwroot (por exemplo, wwwroot/imagens)
                    var diretorioDestino = Path.Combine(_env.WebRootPath, "imagens");

                    // Verifique se o diretório de destino existe, se não, crie-o
                    if (!Directory.Exists(diretorioDestino))
                    {
                        Directory.CreateDirectory(diretorioDestino);
                    }

                    // Caminho completo onde o arquivo será salvo
                    var caminhoCompleto = Path.Combine(diretorioDestino, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await cobrador.FotoArquivo.CopyToAsync(stream);
                    }

                    // Salve o nome do arquivo no banco de dados
                    cobrador.FotoUrl = nomeArquivo;
                }

                cobrador.Senha = BCrypt.Net.BCrypt.HashPassword(cobrador.Senha);
                _context.Add(cobrador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");

            }
            return View(cobrador);
        }



        /* [Authorize(Roles = "Admin,User")]
		  GET: Cobradores/Edit/5
		 public async Task<IActionResult> Edit(int? id)
		 {
			 if (id == null || _context.Cobradores == null)
			 {
				 return NotFound();
			  }

			 var cobrador = await _context.Cobradores.FindAsync(id);
			 if (cobrador == null)
			 {
				 return NotFound();
			 }
			 return View("Views/Cobradores/Details", cobrador);
		 }
		*/

        [Authorize(Roles = "Admin,User")]
        // POST: Cobradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(include: "Id,NomeCobrador,SobrenomeCobrador,CPF,Email,CEP,Endereco,Bairro,Cidade,UF,Telefone,Senha,Perfil, FotoUrl")] Cobrador cobrador)
        {

            if (id != cobrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                // Retira o ponto e o tracinho do CPF antes de validar
                cobrador.CPF = cobrador.CPF.Replace(".", "").Replace("-", "");

                // Verifica se o CPF tem 11 dígitos e se tem apenas números

                if (cobrador.CPF.Length != 11 || !cobrador.CPF.All(char.IsDigit))
                {
                    TempData["ErrorMessage"] = "O CPF deve ter exatamente 11 digitos.";
                    return RedirectToAction("Details", "Cobradores", new { id = cobrador.Id });
                }

                // Retira o tracinho do CEP antes de validar
                cobrador.CEP = cobrador.CEP.Replace("-", "");
                // Verifica o formato do CEP
                if (cobrador.CEP.Length != 8 || !cobrador.CEP.All(char.IsDigit))
                {
                    TempData["ErrorMessage"] = "O CEP deve ter exatamente 8 digitos.";
                    return RedirectToAction("Details", "Cobradores", new { id = cobrador.Id });
                }

                try
                {
                    _context.Update(cobrador);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Cobradores", new { id = cobrador.Id });
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!CobradorExists(cobrador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }

            // Se houver erros de validação, permaneça na mesma view para exibir mensagens de erro.
            return View(cobrador);
        }

        // GET: Cobradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobradores == null)
            {
                return NotFound();
            }

            var cobrador = await _context.Cobradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobrador == null)
            {
                return NotFound();
            }

            return View(cobrador);
        }

        // POST: Cobradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobradores == null)
            {
                return Problem("Entity set 'AppDbContext.Cobradores'  is null.");
            }
            var cobrador = await _context.Cobradores.FindAsync(id);
            if (cobrador != null)
            {
                _context.Cobradores.Remove(cobrador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobradorExists(int id)
        {
            return _context.Cobradores.Any(e => e.Id == id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> UpdateImage([FromForm] ImageUpdateRequest request, int id)
        {
            var cobrador = await _context.Cobradores.FindAsync(id);

            if (cobrador == null)
            {
                return Json(new {
                    error = 1,
                    msg = "Cobrador não encontrado no sistema"
                });

            }

            if (cobrador.FotoUrl != null)
            {
                var diretorioImagem = Path.Combine(_env.WebRootPath, "imagens");
                var diretorioFoto = Path.Combine(diretorioImagem, cobrador.FotoUrl);
                
                if (System.IO.File.Exists(diretorioFoto))
                {
                    System.IO.File.Delete(diretorioFoto);
                }
            }

            var nomeArquivo = Guid.NewGuid().ToString() + "_" + Path.GetFileName(request.File.FileName);
            var diretorioDestino = Path.Combine(_env.WebRootPath, "imagens");
            var diretorioCompleto = Path.Combine(diretorioDestino, nomeArquivo);

            using (var stream = new FileStream(diretorioCompleto, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            cobrador.FotoUrl = nomeArquivo;

            _context.Update(cobrador);
            await _context.SaveChangesAsync();

            return Json(new { error = '0', msg = "Foto atualizada com sucesso", newFoto = cobrador.FotoUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmail(int id)
        {
            var cobranca = await _context.Cobranca
                .Include(cliente => cliente.Cliente)
                .Include(cobrador => cobrador.Cobrador)
                .FirstAsync(cobranca => cobranca.Id == id);
            
            if (cobranca == null)
            {
                return StatusCode(500);
            }

            if (cobranca.CodigoStatus == 2)
            {
                return StatusCode(406);
            }

            string nomeCompleto = cobranca.Cobrador.NomeCobrador + cobranca.Cobrador.SobrenomeCobrador;
           
            EmailDto request = new EmailDto();
            request.To = cobranca.Cliente.Email;
            request.Subject = nomeCompleto + " - Cobrança de serviços prestados";
            request.Body = "<h1>Cobrança de " + cobranca.Valor + " paga com sucesso</h1>";
            
            _emailService.SendEmail(request);

            cobranca.CodigoStatus = 2;
            cobranca.StatusCobranca = "Pago";
            cobranca.Pagamento = DateTime.Now;
            _context.Update(cobranca);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class ImageUpdateRequest
    {
        public IFormFile File { get; set; }
    }
}
