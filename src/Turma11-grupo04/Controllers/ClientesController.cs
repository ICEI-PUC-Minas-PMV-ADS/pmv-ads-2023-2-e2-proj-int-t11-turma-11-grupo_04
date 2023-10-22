using Cadastro_cliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_cliente.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Clientes.ToListAsync();
            
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
