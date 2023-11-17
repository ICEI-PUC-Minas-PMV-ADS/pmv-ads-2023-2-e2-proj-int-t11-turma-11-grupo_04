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
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Mvc.Diagnostics;

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
        public async Task<IActionResult> Index(int id)
        {
            bool isAdmin = User.IsInRole("Admin");

            var cobrador = await _context.Cobradores
                .FirstAsync(c => c.Id == id);

            if (cobrador == null)
            {
                return NotFound();
            }
            
            var cobrancasCobrador = await _context.Cobranca
                .Include(cobranca => cobranca.Cliente)
                .Where(cobranca => cobranca.CobradorId == id)
                .ToListAsync();

            ViewBag.CobradorInfo = cobrador;
            return View(cobrancasCobrador);
        }


        // GET: Cobrancas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobranca == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobranca
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
        public async Task<IActionResult> Create(int id)
        {
            var cobrador = await _context.Cobradores
                .FirstAsync(cobrador => cobrador.Id == id);

            if (cobrador == null)
            {
                // Tratar como validar dps 
                return NotFound();
            }

            ViewBag.CobradorInfo = cobrador;
            ViewData["ClienteId"] = new SelectList(_context.Clientes.Where(c => c.CobradorId == cobrador.Id), "Id", "NomeCliente");

            return View();
        }



        // POST: Cobrancas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Data,Vencimento,Valor,ClienteId,CobradorId")] Cobranca cobranca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobranca);
                await _context.SaveChangesAsync();
                return RedirectToAction("index", "Cobrancas", new { id = cobranca.CobradorId });
            } 
            return View(cobranca);
        }

        // GET: Cobrancas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobranca.FindAsync(id);

            if (cobranca == null)
            {
                return NotFound();
            }

            bool isAdmin = User.IsInRole("Admin");

            if (isAdmin)
            {
                var clientes = _context.Clientes.ToList();
                var cobradores = _context.Cobradores.ToList();

                var clientesSelectList = clientes
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.GetNomeCompleto() });

                ViewData["ClienteId"] = new SelectList(clientesSelectList, "Value", "Text", cobranca.ClienteId);
                ViewData["CobradorId"] = new SelectList(cobradores, "Id", "NomeCobrador", cobranca.CobradorId);
            }
            else
            {
                var cobradorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var clientesDoCobrador = _context.Clientes
                    .Where(c => c.CobradorId == cobradorId)
                    .ToList();

                var cobradoresDoCobrador = _context.Cobradores
                    .Where(c => c.Id == cobradorId)
                    .ToList();

                var clientesSelectList = clientesDoCobrador
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.GetNomeCompleto() });

                ViewData["ClienteId"] = new SelectList(clientesSelectList, "Value", "Text", cobranca.ClienteId);
                ViewData["CobradorId"] = new SelectList(cobradoresDoCobrador, "Id", "NomeCobrador", cobranca.CobradorId);
            }

            return View(cobranca);
        }


        // POST: Cobrancas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Vencimento,Valor")] Cobranca cobranca)
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
            if (id == null || _context.Cobranca  == null)
            {
                return NotFound();
            }

            var cobranca = await _context.Cobranca
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
            if (_context.Cobranca == null)
            {
                return Problem("Entity set 'AppDbContext.Cobranças'  is null.");
            }
            var cobranca = await _context.Cobranca.FindAsync(id);
            if (cobranca != null)
            {
                _context.Cobranca.Remove(cobranca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Cobrancas",new { id = cobranca.CobradorId });
        }

        private bool CobrancaExists(int id)
        {
          return _context.Cobranca.Any(e => e.Id == id);
        }
    }
}
