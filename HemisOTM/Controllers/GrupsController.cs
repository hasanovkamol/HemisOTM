using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModelEntity.Entity;

namespace HemisOTM.Controllers
{
    public class GrupsController : Controller
    {
        private readonly EntityDbContext _context;

        public GrupsController(EntityDbContext context)
        {
            _context = context;
        }

        // GET: Grups
        public async Task<IActionResult> Index()
        {
            var entityDbContext = _context.Grups.Include(g => g.GetStudent);
            return View(await entityDbContext.ToListAsync());
        }

        // GET: Grups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grups
                .Include(g => g.GetStudent)
                .FirstOrDefaultAsync(m => m.GrupId == id);
            if (grup == null)
            {
                return NotFound();
            }

            return View(grup);
        }

        // GET: Grups/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Grups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupId,Name,StudentId")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", grup.StudentId);
            return View(grup);
        }

        // GET: Grups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grups.FindAsync(id);
            if (grup == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", grup.StudentId);
            return View(grup);
        }

        // POST: Grups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupId,Name,StudentId")] Grup grup)
        {
            if (id != grup.GrupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupExists(grup.GrupId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", grup.StudentId);
            return View(grup);
        }

        // GET: Grups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grups
                .Include(g => g.GetStudent)
                .FirstOrDefaultAsync(m => m.GrupId == id);
            if (grup == null)
            {
                return NotFound();
            }

            return View(grup);
        }

        // POST: Grups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grup = await _context.Grups.FindAsync(id);
            _context.Grups.Remove(grup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupExists(int id)
        {
            return _context.Grups.Any(e => e.GrupId == id);
        }
    }
}
