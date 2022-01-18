#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortoBaixada.Models;

namespace PortoBaixada.Controllers
{
    public class ConteinersController : Controller
    {
        private readonly Contexto _context;

        public ConteinersController(Contexto context)
        {
            _context = context;
        }

        // GET: Conteiners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conteiners.ToListAsync());
        }

        // GET: Conteiners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // GET: Conteiners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conteiners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomeCliente,Codigo,Tipo,Status,Categoria,TipoMovimentacao,DataInicial,DataFinal")] Conteiner conteiner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteiner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conteiner);
        }

        // GET: Conteiners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners.FindAsync(id);
            if (conteiner == null)
            {
                return NotFound();
            }
            return View(conteiner);
        }

        // POST: Conteiners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomeCliente,Codigo,Tipo,Status,Categoria,TipoMovimentacao,DataInicial,DataFinal")] Conteiner conteiner)
        {
            if (id != conteiner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteiner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteinerExists(conteiner.ID))
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
            return View(conteiner);
        }

        // GET: Conteiners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // POST: Conteiners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conteiner = await _context.Conteiners.FindAsync(id);
            _context.Conteiners.Remove(conteiner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteinerExists(int id)
        {
            return _context.Conteiners.Any(e => e.ID == id);
        }
    }
}
