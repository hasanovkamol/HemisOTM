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
    public class FacultetsController : Controller
    {
        private readonly EntityDbContext _context;

        public FacultetsController(EntityDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facultets.ToListAsync());
        }
        public IActionResult Create()
        {
            var _facultets = _context.Facultets.ToList();
            ViewBag.facultets = _facultets;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultetID,Name")] Facultet facultet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultet);
                await _context.SaveChangesAsync();
                var _facultets = _context.Facultets.ToList();
                ViewBag.facultets = _facultets;
                return View();
            }
            return View(facultet);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultet = await _context.Facultets.FindAsync(id);
            if (facultet == null)
            {
                return NotFound();
            }
            return View(facultet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacultetID,Name")] Facultet facultet)
        {
            if (id != facultet.FacultetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultetExists(facultet.FacultetID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Create));
            }
            return View(facultet);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultet = await _context.Facultets
                .FirstOrDefaultAsync(m => m.FacultetID == id);
            if (facultet == null)
            {
                return NotFound();
            }

            return View(facultet);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultet = await _context.Facultets.FindAsync(id);
            _context.Facultets.Remove(facultet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        private bool FacultetExists(int id)
        {
            return _context.Facultets.Any(e => e.FacultetID == id);
        }
    }
}
