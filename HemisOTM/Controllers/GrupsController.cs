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
            Current = new Grup();
            ViewData["DirectionId"] = new SelectList(_context.Directions, "DirectionId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupId,Name,DirectId,isPranet")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                if (grup.isPranet)
                {
                    if(_context.Grups.FirstOrDefault(x=>x.DirectId==grup.DirectId)==null)
                    {
                        _context.Add(grup);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                   
                }
                else
                {
                    _context.Add(grup);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            ViewData["DirectionId"] = new SelectList(_context.Directions, "DirectionId", "Name");
            return View(grup);
        }
        [HttpGet]
        public async  Task<IActionResult> Select(int? Id)
        {
            if (Current.GrupId != 0)
            {
                var student = _context.Students.Find(Id);
                if(student!=null && Current!=null)
                {
                    student.GrupName = Current.Name;
                    _context.Update(student);
                   await _context.SaveChangesAsync();
                }
            }

            var students =  _context.Students.Include(e=>e.GetDirection)
                .Where(x => x.GrupName == null && x.DirectionId==Current.DirectId).ToArray();
            ViewBag.student = students;
            return View("Edit", Current);
        }
        [HttpGet]
        public async Task<IActionResult> DontSelect(int? Id)
        {
            if (Current.GrupId != 0)
            {
                var student = _context.Students.Find(Id);
                if (student != null && Current != null)
                {
                    student.GrupName = null;
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
            }

            var students = _context.Students.Include(e => e.GetDirection)
                 .Where(x => x.GrupName == Current.Name && x.DirectionId == Current.DirectId).ToArray();
            ViewBag.student = students;
            return View("Edit", Current);
        }
        [HttpGet]
        public  IActionResult AddedStudent()
        {
            if(Current==null)
            {
                return NotFound();
            }
            var students = _context.Students.Include(e => e.GetDirection)
                  .Where(x => x.GrupName == Current.Name && x.DirectionId == Current.DirectId).ToArray();
            ViewBag.student = students;
            return View("Edit", Current);
        }
        [HttpGet]
        public IActionResult DontAddedStudent()
        {
            if (Current == null)
            {
                return NotFound();
            }
            var students = _context.Students.Include(e => e.GetDirection)
                  .Where(x => x.GrupName == null && x.DirectionId == Current.DirectId).ToArray();
            ViewBag.student = students;
            return View("Edit", Current);
        }
        [HttpGet]
        public ActionResult AllStudent(int? id)
        {
            var grup = _context.Grups.Include(e => e.DirectionList)
               .ToList().Find(x => x.GrupId == id);
            if (grup.DirectId > 0)
            {
                var DirectionName = _context.Directions.Where(x => x.DirectionId == grup.DirectId).FirstOrDefault().Name;
                ViewData["DirectionId"] = DirectionName;
            }
            else
            {
                ViewData["DirectionId"] = "Yo'nalish aniqlanmadi";
            }
            var students = _context.Students.Include(e => e.GetDirection)
                  .Where(x=>x.DirectionId == grup.DirectId).ToArray();
            ViewBag.student = students;
            return View("AllStudent");
        }

        public static Grup Current { get; set; }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var grup = _context.Grups.Include(e=>e.DirectionList)
                .ToList().Find(x=>x.GrupId==id);
            if (grup == null)
            {
                return NotFound();
             
            }
            Current = grup;
            
            if (grup.isPranet)
            {
                var students =await _context.Students.Include(x => x.GetDirection)
                    .Where(x=>x.DirectionId==grup.DirectId)
                    .ToListAsync();
                ViewBag.student = students;
            }
            else
            {
                var students = _context.Students.Include(e => e.GetDirection)
                  .Where(x => x.GrupName == Current.Name && x.DirectionId == Current.DirectId).ToArray();
                ViewBag.student = students;
            }
            
                
            if (grup.DirectId > 0)
            {
                var DirectionName = _context.Directions.Where(x => x.DirectionId == grup.DirectId).FirstOrDefault().Name;
                ViewData["DirectionId"] = DirectionName;
            }
            else
            {
                ViewData["DirectionId"] = "Yo'nalish aniqlanmadi";
            }
            
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
                    Current.Name = grup.Name;
                    _context.Update(Current);
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
