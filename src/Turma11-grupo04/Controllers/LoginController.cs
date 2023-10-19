using Microsoft.AspNetCore.Mvc;
using turma11_grupo04.Models;
using Turma11_grupo04.Models;

namespace Turma11_grupo04.Controllers
{
    public class LoginController : Controller
    {

        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Entrar(LoginModel LoginModel)
        {


            try
            {

                if (ModelState.IsValid)
                {

                    var cobrador = _context.Cobrador.FirstOrDefault
                        (c => c.Email == LoginModel.Email && c.Senha == LoginModel.Senha);



                    if (cobrador != null)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {

                        ModelState.AddModelError("", "Credenciais inválidas. Verifique seu email e senha.");
                    }

                }

                return View("Index");
            }

            catch (Exception)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente.";
                return RedirectToAction("Index");
            }
        }
    }
}
