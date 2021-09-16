using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hiba.Data;
using Hiba.Models;
using Microsoft.AspNetCore.Http;
using Hiba.Helper;
using Microsoft.AspNetCore.Hosting;

namespace Hiba.Controllers
{
    public class CoachingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;
        readonly IWebHostEnvironment _webHostEnvironment;

        public CoachingsController(ApplicationDbContext context, IUploadFile upload, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _upload = upload;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Coachings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coaching.ToListAsync());
        }

        // GET: Coachings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coaching
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coaching == null)
            {
                return NotFound();
            }

            return View(coaching);
        }

        // GET: Coachings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coachings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coaching coaching, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "Coaching");
                    coaching.Image = imagepath;
                }
                _context.Add(coaching);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coaching);
        }

        // GET: Coachings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coaching.FindAsync(id);
            if (coaching == null)
            {
                return NotFound();
            }
            return View(coaching);
        }

        // POST: Coachings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Coaching coaching, IFormFile img)
        {
            if (id != coaching.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _upload.UploadFile(img, "Coaching");
                        coaching.Image = imagepath;
                    }
                    _context.Update(coaching);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachingExists(coaching.ID))
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
            return View(coaching);
        }

        // GET: Coachings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coaching
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coaching == null)
            {
                return NotFound();
            }

            return View(coaching);
        }

        // POST: Coachings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coaching = await _context.Coaching.FindAsync(id);
            _context.Coaching.Remove(coaching);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachingExists(int id)
        {
            return _context.Coaching.Any(e => e.ID == id);
        }
    }
}
