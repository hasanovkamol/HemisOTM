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
            return View(await SourseEntity());
        }
         private async Task<List<HarvestPlan>> SourseEntity()
        {
           return await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(s => s.Subject).ToListAsync();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(s => s.Subject)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }

            return View(harvestPlan);
        }
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName");
            ViewData["GrupId"] = new SelectList(_context.Grups.Where(x=>x.isPranet==true), "GrupId", "Name");
            ViewData["DepartmentName"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            var subject = _context.Subjects.Include(s=>s.SubjectBlockType).ToList();
            ViewData["SujcetList"] = subject;
            Current = new HarvestPlan();
            Current.Subjects = new List<SubjectTraingPlan>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HarvestPlanId,Name,DepatmentId,TeacherId,GrupId")] HarvestPlan harvestPlan)
        {
            if (ModelState.IsValid)
            {
                 Allubject();
                 Current = harvestPlan;
                return View("AddSubject");
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups.Where(x => x.isPranet == true), "GrupId", "Name", harvestPlan.GrupId);
            return View(harvestPlan);
        }
        public async Task<IActionResult> SaveSubject()
        {
            if (Current != null)
            {
                _context.Add(Current);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        public  IActionResult Remove(int? Id)
        {
            if (Current == null) return NotFound();
            Current.Subjects.Remove(Current.Subjects.First(x => x.SubjectId == Id));
            AddedSubjectData();
            return View("AddSubject");
        }
        private void Allubject()
        {
            var subject = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            ViewData["SujcetList"] = subject;
        }
        private void AddedSubjectData()
        {
           
            var subject = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            if (Current.Subjects != null)
            {
                ViewData["isAdded"] = "true";
                subject = subject
                    .Where(x => Current.Subjects.FirstOrDefault(p => p.SubjectId == x.SubjectId) != null)
                    .ToList();

            }
            ViewData["SujcetList"] = subject;
        }
        private void DontAddedSubjectData()
        {
            var subject = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            if(Current.Subjects!=null)
            {
                subject = subject
                    .Where(x => Current.Subjects.FirstOrDefault(p => p.SubjectId == x.SubjectId) == null)
                    .ToList();
                
            }
            ViewData["SujcetList"] = subject;
        }
        public IActionResult AddedSubject()
        {
            AddedSubjectData();
            return View("AddSubject");
        }
        public IActionResult DontAddedSubject()
        {
            DontAddedSubjectData();
            return View("AddSubject");
        }
        private static HarvestPlan Current;
        public async Task<IActionResult> Select(int? id)
        {
            var subjects =await _context.Subjects.Include(s => s.SubjectBlockType).ToListAsync();
            var subject = subjects
                .Where(x=>x.SubjectId==id).FirstOrDefault();
            if (Current.Subjects==null)
            {
                Current.Subjects = new List<SubjectTraingPlan>();
            }
            if(subject==null)
            {
                return NotFound();
            }
            
            Current.Subjects.Add(new SubjectTraingPlan() 
            { 
                SubjectId=subject.SubjectId,
                HardvesPlanId=Current.HarvestPlanId
            });
            DontAddedSubjectData();
            return View("AddSubject");
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "Name", harvestPlan.GrupId);
            return View(harvestPlan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HarvestPlanId,Name,DepatmentId,TeacherId,GrupId")] HarvestPlan harvestPlan)
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "Name", harvestPlan.GrupId);
            return View(harvestPlan);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(z=>z.Subject)
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
        public async Task<IActionResult> TraingPlan(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(s => s.Subject)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == Id);
            if (harvestPlan == null)
            {
                return NotFound();
            }
            return View("TraingPlan",harvestPlan);
        }
    }
}
