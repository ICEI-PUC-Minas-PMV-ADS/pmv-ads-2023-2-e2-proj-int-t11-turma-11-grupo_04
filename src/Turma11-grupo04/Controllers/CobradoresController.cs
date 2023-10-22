
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using turma11_grupo04.Models;

namespace Turma11_grupo04.Controllers
{
    public class CobradoresController : Controller
    {
        private readonly AppDbContext _context;
        public CobradoresController(AppDbContext context) 
        {
            _context = context;
        }

        
        
        public async Task<IActionResult> Index()
        {

           var dados = await _context.Cobrador.ToListAsync();
            return View(dados);


        }
        


        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cobrador cobrador)
        {
            if (ModelState.IsValid) 
            {
                _context.Cobrador.Add(cobrador);
                await _context.SaveChangesAsync();
                ViewBag.MensagemCadastro = "Cadastro realizado com sucesso!";

            }

            return View();
        }
    }
}
