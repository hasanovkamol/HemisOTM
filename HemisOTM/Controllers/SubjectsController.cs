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
    [Authorize]
    public class SubjectsController : Controller
    {
        private readonly EntityDbContext _context;

        public SubjectsController(EntityDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.Include(x=>x.SubjectBlockType).ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }
        public IActionResult Create()
        {
            ViewData["SubjectBlock"] = new SelectList(_context.SubjectBlockTypes, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectCode,Name,Lecture,Practical,Laboratory,Seminar,CourseWork,SubjectBlockTypeId,IndependentEducation,OneOne,OneTwo,TwoOneOneOne,OneTwo,TwoOne,TwoTwo,ThreeOne,ThreeTwe,FourOne,FourTwo,KOneOne,KOneTwo,KTwoOne,KTwoTwo,KThreeOne,KThreeTwe,KFourOne,KFourTwo")] Subject subject)
        {                                                                                                                                               
            if (ModelState.IsValid)                                                                                                                     
            {                                                                                                                                           
                _context.Add(subject);                                                                                                                 
                await _context.SaveChangesAsync();                                                                                                     
                return RedirectToAction(nameof(Index));                                                                                                
            }                                                                                                                                          
            ViewData["SubjectBlock"] = new SelectList(_context.SubjectBlockTypes, "Id", "Name");
            return View(subject);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["SubjectBlock"] = new SelectList(_context.SubjectBlockTypes, "Id", "Name");
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectCode,Name,Lecture,Practical,Laboratory,Seminar,CourseWork,SubjectBlockTypeId,IndependentEducation,OneOne,OneTwo,TwoOne,TwoTwo,ThreeOne,ThreeTwe,FourOne,FourTwo,KOneOne,KOneTwo,KTwoOne,KTwoTwo,KThreeOne,KThreeTwe,KFourOne,KFourTwo")] Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectId))
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
            ViewData["SubjectBlock"] = new SelectList(_context.SubjectBlockTypes, "Id", "Name");
            return View(subject);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
