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
            var entityDbContext = _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .Include(h => h.GetDepartment);
            return View(await entityDbContext.ToListAsync());
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
            Current.subjectTraingPlans = new List<SubjectTraingPlan>();
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups.Where(x => x.isPranet == true), "Name", "GrupId", harvestPlan.GrupId);
            return View(harvestPlan);
        }
        public async Task<IActionResult> SaveSubject()
        {
            if (Current != null)
            {
                _context.Add(Current);
                await _context.SaveChangesAsync();
                return View("Index");
            }
            else
            {
                return NotFound();
            }
        }
        private void Allubject()
        {
            var subject = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            ViewData["SujcetList"] = subject;
        }
        private void AddedSubjectData()
        {
           
            var subject = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            if (Current.subjectTraingPlans != null)
            {
                ViewData["isAdded"] = "true";
                subject = subject
                    .Where(x => Current.subjectTraingPlans.FirstOrDefault(p => p.GetSubjectId == x.SubjectId) != null)
                    .ToList();

            }
            ViewData["SujcetList"] = subject;
        }
        private void DontAddedSubjectData()
        {
            var subject = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            if(Current.subjectTraingPlans!=null)
            {
                subject = subject
                    .Where(x => Current.subjectTraingPlans.FirstOrDefault(p => p.GetSubjectId == x.SubjectId) == null)
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
            var subjects = _context.Subjects.Include(s => s.SubjectBlockType).ToList();
            var subject = subjects
                .Where(x=>x.SubjectId==id).FirstOrDefault();
            if (Current.subjectTraingPlans==null)
            {
                Current.subjectTraingPlans = new List<SubjectTraingPlan>();
            }
            if(subject==null)
            {
                return NotFound();
            }
            
            Current.subjectTraingPlans.Add(new SubjectTraingPlan() 
            { 
                GetSubjectId=subject.SubjectId,
                GetSubject=subject,
                GetHardvesPlanId=Current.HarvestPlanId,
                GetHarvestPlan=Current
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", harvestPlan.TeacherId);
            ViewData["GrupId"] = new SelectList(_context.Grups, "GrupId", "GrupId", harvestPlan.GrupId);
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", harvestPlan.TeacherId);
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
