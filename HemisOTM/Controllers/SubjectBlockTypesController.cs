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
    public class SubjectBlockTypesController : Controller
    {
        private readonly EntityDbContext _context;

        public SubjectBlockTypesController(EntityDbContext context)
        {
            _context = context;
        }

        // GET: SubjectBlockTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubjectBlockTypes.ToListAsync());
        }

        // GET: SubjectBlockTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectBlockType = await _context.SubjectBlockTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectBlockType == null)
            {
                return NotFound();
            }

            return View(subjectBlockType);
        }

        // GET: SubjectBlockTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectBlockTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SubjectBlockType subjectBlockType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectBlockType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectBlockType);
        }

        // GET: SubjectBlockTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectBlockType = await _context.SubjectBlockTypes.FindAsync(id);
            if (subjectBlockType == null)
            {
                return NotFound();
            }
            return View(subjectBlockType);
        }

        // POST: SubjectBlockTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SubjectBlockType subjectBlockType)
        {
            if (id != subjectBlockType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectBlockType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectBlockTypeExists(subjectBlockType.Id))
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
            return View(subjectBlockType);
        }

        // GET: SubjectBlockTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectBlockType = await _context.SubjectBlockTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectBlockType == null)
            {
                return NotFound();
            }

            return View(subjectBlockType);
        }

        // POST: SubjectBlockTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjectBlockType = await _context.SubjectBlockTypes.FindAsync(id);
            _context.SubjectBlockTypes.Remove(subjectBlockType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectBlockTypeExists(int id)
        {
            return _context.SubjectBlockTypes.Any(e => e.Id == id);
        }
    }
}
