using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hiba.Data;
using Hiba.Models;
using Hiba.Helper;
using Microsoft.AspNetCore.Http;

namespace Hiba.Controllers
{
    public class LectureWorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;

        public LectureWorkshopsController(ApplicationDbContext context, IUploadFile upload)
        {
            _context = context;
            _upload = upload;
        }

        // GET: LectureWorkshops
        public async Task<IActionResult> Index()
        {
            return View(await _context.LectureWorkshops.ToListAsync());
        }

        // GET: LectureWorkshops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureWorkshop = await _context.LectureWorkshops
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lectureWorkshop == null)
            {
                return NotFound();
            }

            return View(lectureWorkshop);
        }

        // GET: LectureWorkshops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LectureWorkshops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LectureWorkshop lectureWorkshop, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "LectureWorkshop");
                    lectureWorkshop.Image = imagepath;
                }
                _context.Add(lectureWorkshop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lectureWorkshop);
        }

        // GET: LectureWorkshops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureWorkshop = await _context.LectureWorkshops.FindAsync(id);
            if (lectureWorkshop == null)
            {
                return NotFound();
            }
            return View(lectureWorkshop);
        }

        // POST: LectureWorkshops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LectureWorkshop lectureWorkshop, IFormFile img)
        {
            if (id != lectureWorkshop.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _upload.UploadFile(img, "LectureWorkshop");
                        lectureWorkshop.Image = imagepath;
                    }
                    _context.Update(lectureWorkshop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureWorkshopExists(lectureWorkshop.ID))
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
            return View(lectureWorkshop);
        }

        // GET: LectureWorkshops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectureWorkshop = await _context.LectureWorkshops
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lectureWorkshop == null)
            {
                return NotFound();
            }

            return View(lectureWorkshop);
        }

        // POST: LectureWorkshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lectureWorkshop = await _context.LectureWorkshops.FindAsync(id);
            _context.LectureWorkshops.Remove(lectureWorkshop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureWorkshopExists(int id)
        {
            return _context.LectureWorkshops.Any(e => e.ID == id);
        }
    }
}
