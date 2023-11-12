using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Eixo_2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Projeto_Eixo_2.Controllers
{
    public class CobrancasController : Controller
    {
        [HttpGet]
        public IActionResult GetClientesByCobrador(int cobradorId)
        {
            var clientesDoCobrador = _context.Clientes
                .Where(c => c.CobradorId == cobradorId)
                .Select(c => new { Value = c.Id, Text = c.GetNomeCompleto() })
                .ToList();

            return Json(clientesDoCobrador);
        }

        private readonly AppDbContext _context;

        public CobrancasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cobrancas
        public async Task<IActionResult> Index()
        {
            bool isAdmin = User.IsInRole("Admin");

            IQueryable<Cobranca> cobrancasQuery;

            if (isAdmin)
            {
                // Se for administrador, listar todas as cobranças do banco de dados
                cobrancasQuery = _context.Cobranças.Include(c => c.Cliente).Include(c => c.Cobrador);
            }
            else
            {
                // Se não for administrador, obter o ID do cobrador logado
                var cobradorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Consulta para obter apenas as cobranças do cobrador logado
                cobrancasQuery = _context.Cobranças
                    .Where(c => c.CobradorId == cobradorId)
                    .Include(c => c.Cliente)
                    .Include(c => c.Cobrador);
            }

            return View(await cobrancasQuery.ToListAsync());
        }


        // GET: Cobrancas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobranças == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobranças
                .Include(c => c.Cliente)
                .Include(c => c.Cobrador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobranca == null)
            {
                return NotFound();
            }

            return View(cobranca);
        }

        // GET: Cobrancas/Create
        public IActionResult Create()
        {
            bool isAdmin = User.IsInRole("Admin");

            if (isAdmin)
            {
                // Se for administrador, carregar todos os clientes e todos os cobradores
                var clientes = _context.Clientes.ToList();
                var cobradores = _context.Cobradores.ToList();

                // Use o método de extensão GetNomeCompleto para obter o nome completo
                var clientesSelectList = clientes
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.GetNomeCompleto() });

                ViewData["ClienteId"] = new SelectList(clientesSelectList, "Value", "Text");
                ViewData["CobradorId"] = new SelectList(cobradores, "Id", "NomeCobrador");
            }
            else
            {
                // Obtenha o ID do cobrador logado (depende de como você implementou a autenticação)
                var cobradorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Filtrar os clientes associados ao cobrador logado
                var clientesDoCobrador = _context.Clientes
                    .Where(c => c.CobradorId == cobradorId)
                    .ToList();

                // Filtrar os cobradores associados ao cobrador logado
                var cobradoresDoCobrador = _context.Cobradores
                    .Where(c => c.Id == cobradorId)
                    .ToList();

                // Use o método de extensão GetNomeCompleto para obter o nome completo
                var clientesSelectList = clientesDoCobrador
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.GetNomeCompleto() });

                ViewData["ClienteId"] = new SelectList(clientesSelectList, "Value", "Text");
                ViewData["CobradorId"] = new SelectList(cobradoresDoCobrador, "Id", "NomeCobrador");
            }

            return View();
        }



        // POST: Cobrancas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Vencimento,Valor,ClienteId,CobradorId")] Cobranca cobranca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobranca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCliente", cobranca.ClienteId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "NomeCobrador", cobranca.CobradorId);
            return View(cobranca);
        }

        // GET: Cobrancas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobranças == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobranças.FindAsync(id);
            if (cobranca == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCliente", cobranca.ClienteId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "Nome Cobrador", cobranca.CobradorId);
            return View(cobranca);
        }

        // POST: Cobrancas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Vencimento,Valor,ClienteId,CobradorId")] Cobranca cobranca)
        {
            if (id != cobranca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobranca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobrancaExists(cobranca.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeCliente", cobranca.ClienteId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "NomeCobrador", cobranca.CobradorId);
            return View(cobranca);
        }

        // GET: Cobrancas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobranças == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobranças
                .Include(c => c.Cliente)
                .Include(c => c.Cobrador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobranca == null)
            {
                return NotFound();
            }

            return View(cobranca);
        }

        // POST: Cobrancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobranças == null)
            {
                return Problem("Entity set 'AppDbContext.Cobranças'  is null.");
            }
            var cobranca = await _context.Cobranças.FindAsync(id);
            if (cobranca != null)
            {
                _context.Cobranças.Remove(cobranca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobrancaExists(int id)
        {
          return _context.Cobranças.Any(e => e.Id == id);
        }
    }
}
