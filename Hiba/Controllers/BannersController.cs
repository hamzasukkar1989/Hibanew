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
using Microsoft.AspNetCore.Hosting;
using Hiba.Helper;
using System.Globalization;
using System.Threading;

namespace Hiba.Controllers
{
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;
        readonly IWebHostEnvironment _webHostEnvironment;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        public BannersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IUploadFile upload)
        {
            _context = context;
            _upload = upload;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
            var data = await _context.Banners.Where(b=>b.Lang==cultureInfo.ToString()).ToListAsync();
            return View(data);
        }

        // GET: Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner banner, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "Banner");
                    banner.Image = imagepath;
                }
                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Banner banner, IFormFile img)
        {
            if (id != banner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _upload.UploadFile(img, "Banner");
                        banner.Image = imagepath;
                    }
                    if (banner.First==true)
                    {
                        var banners = _context.Banners.Where(b => b.ID != id).ToList();

                        foreach (var _banner in banners)
                        {
                            _banner.First = false;
                        }
                    }
                    if (banner.Secound == true)
                    {
                        var banners = _context.Banners.Where(b=> b.ID!=id).ToList();

                        foreach (var _banner in banners)
                        {
                            _banner.Secound = false;
                        }
                    }
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.ID))
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
            return View(banner);
        }

        // GET: Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return _context.Banners.Any(e => e.ID == id);
        }
    }
}
