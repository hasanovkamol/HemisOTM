using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModelEntity.Entity;
using Syncfusion.HtmlConverter;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Syncfusion.Pdf;

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
                .Include(h => h.Grups).ThenInclude(g=>g.DirectionList)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(s => s.Subject).ToListAsync();
        }
        private static int? CurrentId;
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CurrentId = id;
            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects)
                .ThenInclude(s => s.Subject)
                .ThenInclude(x=>x.SubjectBlockType)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }
            ViewData["subjects"] = harvestPlan.Subjects.Select(x => x.Subject);

            return View(harvestPlan);
        }
        public async Task<IActionResult> Create()
        {
            var list = _context.HarvestPlans.Include(x => x.Grups).Where(x=>x.Grups.isPranet==true).ToList();
            var grup =await _context.Grups.Include(c => c.DirectionList)
                .Where(x => x.isPranet == true)
                .ToListAsync();

            var grups = grup.Where(x => list.FirstOrDefault(y => y.Grups.DirectId == x.DirectId) == null).ToList();
            if (grups.Count >0)
            {
                ViewData["grupItemNull"] = "Hamma gruplar uchun o'quv reja shakilantrilgan";
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "FullName");
            ViewData["GrupId"] = new SelectList(grups, "GrupId", "Name");
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
                Current.Grups = null;
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
        public async Task<IActionResult> TraingPlan()
        {
           int? Id = CurrentId;
            if (Id == null)
            {
                return NotFound();
            }

            var harvestPlan = await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .ThenInclude(g => g.DirectionList)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(s => s.Subject).ThenInclude(d=>d.SubjectBlockType)
                .FirstOrDefaultAsync(m => m.HarvestPlanId == Id);
            var direction = _context.Directions.FirstOrDefault(x => x.DirectionId == harvestPlan.Grups.DirectId);
            ViewData["direction"] = direction;
            if (harvestPlan == null)
            {
                return NotFound();
            }
            var harvestPlan2 = await _context.HarvestPlans
                .Include(h => h.GetTeacher)
                .Include(h => h.Grups)
                .ThenInclude(g => g.DirectionList)
                .Include(h => h.GetDepartment)
                .Include(h => h.Subjects).ThenInclude(s => s.Subject).ThenInclude(d => d.SubjectBlockType)
                .FirstOrDefaultAsync(m => m.Grups.isPranet==true && m.Grups.DirectId==harvestPlan.Grups.DirectId);
            List<Subject> subjects1 = new List<Subject>();
            List<Subject> subjects = new List<Subject>();
          
            foreach (var item in harvestPlan2.Subjects)
            {
                if (subjects.Where(x => x.SubjectId == item.Subject.SubjectId).FirstOrDefault() == null)
                {
                    subjects.Add(item.Subject);
                }

            }
            
            foreach (var item in harvestPlan.Subjects)
            {
                if(subjects.Where(x => x.SubjectId == item.Subject.SubjectId).FirstOrDefault() == null)
                {
                    subjects.Add(item.Subject);
                }
                
            }
            

            var subjectBlockTypes = subjects.GroupBy(x => x.SubjectBlockType.Name)
                .Select(s =>
                new 
                { 
                    Key=s.Key
                });
            
            foreach (var item in subjectBlockTypes)
            {

                var ss = subjects.Where(x=>x.SubjectBlockType.Name==item.Key).ToList();
               
                Subject subject = new Subject()
                {
                    Name = item.Key,
                    Lecture = ss.Sum(x => x.Lecture),
                    Seminar = ss.Sum(x => x.Seminar),
                    Practical = ss.Sum(x => x.Practical),
                    Laboratory = ss.Sum(x => x.Laboratory),
                    CourseWork = ss.Sum(x => x.CourseWork),
                    IndependentEducation = ss.Sum(x => x.IndependentEducation),
                   
                    OneOne = ss.Sum(x => x.OneOne),
                    OneTwo = ss.Sum(x => x.OneTwo),
                    TwoOne = ss.Sum(x => x.TwoOne),
                    TwoTwo = ss.Sum(x => x.TwoTwo),
                    ThreeOne = ss.Sum(x => x.ThreeOne),
                    ThreeTwo = ss.Sum(x => x.ThreeTwo),
                    FourOne = ss.Sum(x => x.FourOne),
                    FourTwo = ss.Sum(x => x.FourTwo),

                    KOneOne = ss.Sum(x => x.KOneOne),
                    KOneTwo = ss.Sum(x => x.KOneTwo),
                    KTwoOne = ss.Sum(x => x.KTwoOne),
                    KTwoTwo = ss.Sum(x => x.KTwoTwo),
                    KThreeOne = ss.Sum(x => x.KThreeOne),
                    KThreeTwo = ss.Sum(x => x.KThreeTwo),
                    KFourOne = ss.Sum(x => x.KFourOne),
                    KFourTwo = ss.Sum(x => x.KFourTwo),

                };
              
                subjects1.Add(subject);
                subjects1.AddRange(ss);
            }

            ViewData["sumClock"] = 700;

            ViewData["subjects"] = subjects1;
            return View("TraingPlan",harvestPlan);
        }

        public async Task<IActionResult> CreateGrupChild(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var harvestPlan = await _context.HarvestPlans
                .FirstOrDefaultAsync(m => m.HarvestPlanId == id);
            if (harvestPlan == null)
            {
                return NotFound();
            }
           
            Current = harvestPlan;
            Current.HarvestPlanId = 0;
            int GrupId = _context.Grups.FirstOrDefault(x => x.GrupId == Current.GrupId).DirectId;
            ViewData["GrupId"] = new SelectList(_context.Grups.Where(x => x.isPranet == false && x.DirectId== GrupId), "GrupId", "Name");

            return View("CreateGrupChild",Current);
        }
        public async Task<IActionResult> SaveChild(string Name,int GrupId)
        {
            if (ModelState.IsValid)
            {
                Allubject();
                Current.Name = Name;
                Current.GrupId = GrupId;
                return View("AddSubject");
            }

            ViewData["GrupId"] = new SelectList(_context.Grups.Where(x => x.isPranet == false && x.DirectId == Current.Grups.DirectId), "GrupId", "Name");
            return View(Current);
        }
        public IActionResult ExportToPdf()
        {
            //HtmlToPdfConverter pdfConverter = new HtmlToPdfConverter();
            //WebKitConverterSettings settings = new WebKitConverterSettings();
            //settings.WebKitPath = "QtBinariesWindows";
            //PdfDocument document = pdfConverter.Convert()
            return View();
        }
    }
}
