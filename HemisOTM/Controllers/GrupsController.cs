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

        public async Task<IActionResult> Index()
        {
            var entityDbContext = _context.Grups;
            return View(await entityDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grups
                .FirstOrDefaultAsync(m => m.GrupId == id);
            if (grup == null)
            {
                return NotFound();
            }

            return View(grup);
        }

         public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupId,Name")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           return View(grup);
        }
        public void Select(int? StudentId)
        {
            if (GrupId != 0)
            {

            }
        }
        private static int? GrupId=0;
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
            GrupId = id;
            var students = _context.Students.Include(x => x.GetDirection).ToList();
            ViewBag.student = students;
            return View(grup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupId,Name")] Grup grup)
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
            return View(grup);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grup = await _context.Grups
                .FirstOrDefaultAsync(m => m.GrupId == id);
            if (grup == null)
            {
                return NotFound();
            }

            return View(grup);
        }

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
