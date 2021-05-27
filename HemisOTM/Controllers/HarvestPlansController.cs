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

        public async Task<IActionResult> Index()
        {
            var entityDbContext = _context.HarvestPlans.Include(h => h.subjectTraingPlans).Include(h => h.GetTeacher).Include(h => h.Grups);
            return View(await entityDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.subjectTraingPlans)
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }

            return View(harvestPlan);
        }
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectCode");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId");
            //ViewData["Department"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            return View();
        }

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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectCode");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }

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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectCode");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }

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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectCode");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.subjectTraingPlans)
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }

            return View(harvestPlan);
        }

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
