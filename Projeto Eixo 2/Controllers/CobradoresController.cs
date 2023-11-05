using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Eixo_2.Models;

namespace Projeto_Eixo_2.Controllers
{
    public class CobradoresController : Controller
    {

        private readonly AppDbContext _context;

        public CobradoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cobradores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cobradores.ToListAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

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
                     new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()), // Adicione o ID do cobrador como claim
                     new Claim(ClaimTypes.Email, dados.Email.ToString())
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

                return RedirectToAction("Index", "Home"); // Redireciona para a homepage
            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha incorretos";
            }

            return View();
        }

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

            var cobrador = await _context.Cobradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobrador == null)
            {
                return NotFound();
            }

            return View(cobrador);
        }

        // GET: Cobradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cobradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCobrador,SobrenomeCobrador,CPF,Email,Telefone,Senha")] Cobrador cobrador)
        {
            if (ModelState.IsValid)
            {
                cobrador.Senha = BCrypt.Net.BCrypt.HashPassword(cobrador.Senha);
                _context.Add(cobrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cobrador);
        }

        // GET: Cobradores/Edit/5
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
            return View(cobrador);
        }

        // POST: Cobradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCobrador,SobrenomeCobrador,CPF,Email,Telefone,Senha")] Cobrador cobrador)
        {
            if (id != cobrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cobrador.Senha = BCrypt.Net.BCrypt.HashPassword(cobrador.Senha);
                    _context.Update(cobrador);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
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
    }
}
