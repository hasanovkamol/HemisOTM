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
    public class HarvestPlansController : Controller
    {
        private readonly EntityDbContext _context;

        public HarvestPlansController(EntityDbContext context)
        {
            _context = context;
        }

        // GET: HarvestPlans
        public async Task<IActionResult> Index()
        {
            var entityDbContext = _context.HarvestPlans.Include(h => h.GetSubject).Include(h => h.GetTeacher).Include(h => h.Grups);
            return View(await entityDbContext.ToListAsync());
        }

        // GET: HarvestPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetSubject)
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }

            return View(harvestPlan);
        }

        // GET: HarvestPlans/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId");
            return View();
        }

        // POST: HarvestPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HarvestPlanId,Name,Depatment,TeacherId,SubjectId,GrupId,BlockTypeId")] HarvestPlan harvestPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harvestPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", harvestPlan.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }

        // GET: HarvestPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans.FindAsync(id);
            if (harvestPlan == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", harvestPlan.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }

        // POST: HarvestPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HarvestPlanId,Name,Depatment,TeacherId,SubjectId,GrupId,BlockTypeId")] HarvestPlan harvestPlan)
        {
            if (id != harvestPlan.HarvestPlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harvestPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarvestPlanExists(harvestPlan.HarvestPlanId))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", harvestPlan.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }

        // GET: HarvestPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetSubject)
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }

            return View(harvestPlan);
        }

        // POST: HarvestPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var harvestPlan = await _context.HarvestPlans.FindAsync(id);
            _context.HarvestPlans.Remove(harvestPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarvestPlanExists(int id)
        {
            return _context.HarvestPlans.Any(e => e.HarvestPlanId == id);
        }
    }
}
