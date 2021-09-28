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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using System.Threading;

namespace Hiba.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;
        readonly IWebHostEnvironment _webHostEnvironment;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;


        public NewsController(ApplicationDbContext context, IUploadFile upload, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _upload = upload;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: News
        public async Task<IActionResult> News(int id)
        {
            var data = await _context.News.SingleOrDefaultAsync(N => N.ID == id);
            return View(data);
        }

        public async Task<IActionResult> List()
        {
            var news = await _context.News.Where(n => n.Lang == cultureInfo.ToString()).ToListAsync();
            return View(news);
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        public async Task<IActionResult> Pagination()
        {
            return View();
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.ID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news, IFormFile img)
        {
            if (ModelState.IsValid)
            {

                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "News");
                    news.Image = imagepath;
                }
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, News news, IFormFile img)
        {
            if (id != news.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _upload.UploadFile(img, "News");
                        news.Image = imagepath;
                    }
                    _context.Add(news);
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.ID))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.ID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.ID == id);
        }
    }
}
