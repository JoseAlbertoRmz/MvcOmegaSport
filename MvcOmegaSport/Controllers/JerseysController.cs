#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOmegaSport.Data;
using MvcOmegaSport.Models;

namespace MvcOmegaSport.Controllers
{
    public class JerseysController : Controller
    {
        private readonly MvcOmegaSportContext _context;

        public JerseysController(MvcOmegaSportContext context)
        {
            _context = context;
        }

        // GET: Jerseys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jersey.ToListAsync());
        }

        // GET: Jerseys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jersey = await _context.Jersey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jersey == null)
            {
                return NotFound();
            }

            return View(jersey);
        }

        // GET: Jerseys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jerseys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Talla,Equipacion,Marca,Precio")] Jersey jersey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jersey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jersey);
        }

        // GET: Jerseys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jersey = await _context.Jersey.FindAsync(id);
            if (jersey == null)
            {
                return NotFound();
            }
            return View(jersey);
        }

        // POST: Jerseys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Talla,Equipacion,Marca,Precio")] Jersey jersey)
        {
            if (id != jersey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jersey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JerseyExists(jersey.Id))
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
            return View(jersey);
        }

        // GET: Jerseys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jersey = await _context.Jersey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jersey == null)
            {
                return NotFound();
            }

            return View(jersey);
        }

        // POST: Jerseys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jersey = await _context.Jersey.FindAsync(id);
            _context.Jersey.Remove(jersey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JerseyExists(int id)
        {
            return _context.Jersey.Any(e => e.Id == id);
        }
    }
}
