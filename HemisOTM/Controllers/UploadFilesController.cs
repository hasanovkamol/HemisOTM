using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModelEntity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace HemisOTM.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly EntityDbContext _context;

        IWebHostEnvironment _appEnvironment;
        public UploadFilesController(EntityDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: UploadFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UploadFiles.ToListAsync());
        }

        // GET: UploadFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadFile = await _context.UploadFiles
                .FirstOrDefaultAsync(m => m.FileId == id);
            if (uploadFile == null)
            {
                return NotFound();
            }

            return View(uploadFile);
        }

        public IActionResult Create()
        {
            var books = _context.UploadFiles.ToList();
            ViewBag.Books = books;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FileId,FileName,Url")] UploadFile uploadFile,[Bind("urlFile")] IFormFile urlFile)
        {
            var books = _context.UploadFiles.ToList();
            ViewBag.Books = books;
            if (ModelState.IsValid)
            {
                _context.Add(uploadFile);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(uploadFile);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadFile = await _context.UploadFiles.FindAsync(id);
            if (uploadFile == null)
            {
                return NotFound();
            }
            return View(uploadFile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FileId,FileName,Url")] UploadFile uploadFile)
        {
            if (id != uploadFile.FileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uploadFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadFileExists(uploadFile.FileId))
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
            return View(uploadFile);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadFile = await _context.UploadFiles
                .FirstOrDefaultAsync(m => m.FileId == id);
            if (uploadFile == null)
            {
                return NotFound();
            }

            return View(uploadFile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uploadFile = await _context.UploadFiles.FindAsync(id);
            _context.UploadFiles.Remove(uploadFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UploadFileExists(int id)
        {
            return _context.UploadFiles.Any(e => e.FileId == id);
        }
    }
}
