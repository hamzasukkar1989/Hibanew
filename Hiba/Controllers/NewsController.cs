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
using Newtonsoft.Json;

namespace Hiba.Controllers
{
    
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _myupload;
        readonly IWebHostEnvironment _webHostEnvironment;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;


        public NewsController(ApplicationDbContext context, IUploadFile upload, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _myupload = upload;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: News
        [HttpPost]
        public async Task<ActionResult> UploadImageAsync(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string imagepath = "";
            string filename = upload.FileName;


            if (upload != null && upload.Length > 0)
            {
                 imagepath = await _myupload.UploadFile(upload, "News");
            }

            
            //var url = $"{"/images/CKEditorImages/"}{fileName}";
            var url = imagepath;
            string callback = Request.Query["CKEditorFuncNum"];//Request return value
                                                               //var successMessage = "image is uploaded successfully";
                                                               //dynamic success = JsonConvert.DeserializeObject("{ 'uploaded': 1,'fileName': \"" + filename + "\",'url': \"" + url + "\", 'error': { 'message': \"" + successMessage + "\"}}");
                                                               //return Json(success);

            //string tpl = "<script type=\"text/javascript\">window.parent.CKEDITOR.tools.callFunction(\"{1}\", \"{0}\", \"{2}\");</script>";
            //return Content(string.Format(tpl, url, callback, ""), "text/html");


            // return Content("<script type ='text/javascript' > window.parent.CKEDITOR.tools.callFunction("+1+", '" + Url+"', '');</ script > ");
            return Content(url);


        }
 
        public async Task<IActionResult> News(int id)
        {
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
            }
            var data = await _context.News.SingleOrDefaultAsync(N => N.ID == id);
            return View(data);
        }

        public async Task<IActionResult> List()
        {
            ViewBag.NewsTitle = "News";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.NewsTitle = "الأخبار";
            }
            var news = await _context.News.Where(n => n.Lang == cultureInfo.ToString()).ToListAsync();
            return View(news);
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        public IActionResult Pagination()
        {
            return  View();
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
                    string imagepath = await _myupload.UploadFile(img, "News");
                    news.Image = imagepath;
                }
                var getnewsSequence = _context.News.SingleOrDefault(n => n.Sequence == news.Sequence && n.Lang == cultureInfo.ToString());
                if (getnewsSequence!=null)
                {
                    getnewsSequence.Sequence = Common.Enums.Sequence.Not;
                    _context.Update(getnewsSequence);
                }
                
                _context.Add(news);
                _context.SaveChanges();
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
                    var getnewsSequence = _context.News.SingleOrDefault(n => n.Sequence == news.Sequence && n.ID !=news.ID && n.Lang == cultureInfo.ToString());

                    if (getnewsSequence != null)
                    {
                        getnewsSequence.Sequence = Common.Enums.Sequence.Not;
                        _context.Update(getnewsSequence);
                    }

                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _myupload.UploadFile(img, "News");
                        news.Image = imagepath;
                    }
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
