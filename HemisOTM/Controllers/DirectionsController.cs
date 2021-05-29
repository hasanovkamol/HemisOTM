using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModelEntity.Entity;
using Microsoft.AspNetCore.Authorization;

namespace HemisOTM.Controllers
{
    public class DirectionsController : Controller
    {
        private readonly EntityDbContext _context;

        public DirectionsController(EntityDbContext context)
        {
            _context = context;
        }

     

        public IActionResult Create()
        {
            var directions = _context.Directions.ToList();
            ViewBag.direction = directions;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectionId,Code,Name")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direction);
                await _context.SaveChangesAsync();

            }
            var directions = _context.Directions.ToList();
            ViewBag.direction = directions;
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions.FindAsync(id);
            if (direction == null)
            {
                return NotFound();
            }
            return View(direction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectionId,Code,Name")] Direction direction)
        {
            if (id != direction.DirectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectionExists(direction.DirectionId))
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
            return View(direction);
        }

         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions
                .FirstOrDefaultAsync(m => m.DirectionId == id);
            if (direction == null)
            {
                return NotFound();
            }

            return View(direction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direction = await _context.Directions.FindAsync(id);
            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectionExists(int id)
        {
            return _context.Directions.Any(e => e.DirectionId == id);
        }
    }
}
