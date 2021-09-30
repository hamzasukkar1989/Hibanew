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
using static Hiba.Common.Enums;

namespace Hiba.Controllers
{
    public class CooperationAndPartnersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

        public CooperationAndPartnersController(ApplicationDbContext context, IUploadFile upload)
        {
            _context = context;
            _upload = upload;
        }

        // GET: CooperationAndPartners
        public async Task<IActionResult> Index()
        {
            return View(await _context.CooperationAndPartners.ToListAsync());
        }

        public IActionResult CooperationAndPartners()
        {


            ViewBag.Title1 = "Cooperation ";
            ViewBag.Title2 = "AndPartners";
            ViewBag.Individual = "Individual";
            ViewBag.Organizations = "Organizations";
            ViewBag.align = "left";

            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "تعاون و";
                ViewBag.Title2 = "شركاء";
                ViewBag.Individual = "أفراد";
                ViewBag.Organizations = "هيئات ومؤسسات";
                ViewBag.align = "right";
            }

            var data = _context.Pages.SingleOrDefault(p => p.Name == "Cooperation And Partners" && p.Lang == cultureInfo.ToString());
            return View(data);
        }
        public IActionResult Individual()
        {
            ViewBag.Title1 = "Individual";

            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "أفراد";
            }

            var data = _context.CooperationAndPartners
                .Where(i => i.CooperationAndPartnersType == CooperationAndPartnersType.Individual && i.Lang == cultureInfo.ToString()).ToList();
            return View(data);
        }

        public IActionResult Page(int id)
        {
            var data = _context.CooperationAndPartners.SingleOrDefault(p => p.ID == id);
            return View(data);
        }
        public IActionResult OrganizationsAndInstitutions()
        {
            ViewBag.Title1 = "Organizations";
            ViewBag.Title2 = " and institutions";

            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "هيئات";
                ViewBag.Title2 = "ومؤسسات";
            }
            var data = _context.CooperationAndPartners
                .Where(i => i.CooperationAndPartnersType == CooperationAndPartnersType.OrganizationsAndInstitutions && i.Lang == cultureInfo.ToString()).ToList();
            return View(data);
        }
        public async Task<IActionResult> List()
        {
            return View(await _context.CooperationAndPartners.ToListAsync());
        }

        // GET: CooperationAndPartners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cooperationAndPartners = await _context.CooperationAndPartners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cooperationAndPartners == null)
            {
                return NotFound();
            }

            return View(cooperationAndPartners);
        }

        // GET: CooperationAndPartners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CooperationAndPartners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CooperationAndPartners cooperationAndPartners, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "CooperationAndPartners");
                    cooperationAndPartners.Image = imagepath;
                }
                _context.Add(cooperationAndPartners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cooperationAndPartners);
        }

        // GET: CooperationAndPartners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cooperationAndPartners = await _context.CooperationAndPartners.FindAsync(id);
            if (cooperationAndPartners == null)
            {
                return NotFound();
            }
            return View(cooperationAndPartners);
        }

        // POST: CooperationAndPartners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CooperationAndPartners cooperationAndPartners, IFormFile img)
        {
            if (id != cooperationAndPartners.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (img != null && img.Length > 0)
                    {
                        string imagepath = await _upload.UploadFile(img, "CooperationAndPartners");
                        cooperationAndPartners.Image = imagepath;
                    }
                    _context.Update(cooperationAndPartners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CooperationAndPartnersExists(cooperationAndPartners.ID))
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
            return View(cooperationAndPartners);
        }

        // GET: CooperationAndPartners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cooperationAndPartners = await _context.CooperationAndPartners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cooperationAndPartners == null)
            {
                return NotFound();
            }

            return View(cooperationAndPartners);
        }

        // POST: CooperationAndPartners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cooperationAndPartners = await _context.CooperationAndPartners.FindAsync(id);
            _context.CooperationAndPartners.Remove(cooperationAndPartners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CooperationAndPartnersExists(int id)
        {
            return _context.CooperationAndPartners.Any(e => e.ID == id);
        }
    }
}
