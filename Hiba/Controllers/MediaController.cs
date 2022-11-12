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
using System.Globalization;
using System.Threading;
using Newtonsoft.Json;

namespace Hiba.Controllers
{
    public class MediaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        public MediaController(ApplicationDbContext context, IUploadFile upload)
        {
            _context = context;
            _upload = upload;
        }

        public async Task<IActionResult> UploadImage(IFormFile upload)
        {

            string imagepath = "";
            if(upload != null && upload.Length > 0)
            {
                 imagepath = await _upload.UploadFile(upload, "Medias");
                
            }
            //var successMessage = "image is uploaded successfully";
            ////return new JsonResult(new { path = imagepath });
            //return Content(imagepath);

            var success = new uploadsuccess
            {
                Uploaded = 1,
                Url = imagepath
            };

            return new JsonResult(success);

        }
        public class uploadsuccess
        {
            public int Uploaded { get; set; }
            public string FileName { get; set; }
            public string Url { get; set; }
        }

        public async Task<IActionResult> List()
        {
            ViewBag.Title1 = "Photos";
            ViewBag.Title2 = "Album";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "ألبوم";
                ViewBag.Title2 = "الصور";
            }
            return View(await _context.Medias.Where(m=>m.Lang==cultureInfo.ToString()).ToListAsync());
        }
        public async Task<IActionResult> Media(int id)
        {
            var data = await _context.Medias.SingleOrDefaultAsync(m=>m.ID==id);
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
            }
            return View(data);
        }
        // GET: Media
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medias.ToListAsync());
        }

        // GET: Media/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .FirstOrDefaultAsync(m => m.ID == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Media media, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "Medias");
                    media.Image = imagepath;
                }
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Media media, IFormFile img)
        {
            if (id != media.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _upload.UploadFile(img, "Medias");
                        media.Image = imagepath;
                    }
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.ID))
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
            return View(media);
        }

        // GET: Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .FirstOrDefaultAsync(m => m.ID == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Medias.FindAsync(id);
            _context.Medias.Remove(media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Medias.Any(e => e.ID == id);
        }
    }
}
