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
using Hiba.Common;

namespace Hiba.Controllers
{
    public class AddToYourInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;

        public AddToYourInformationsController(ApplicationDbContext context, IUploadFile upload)
        {
            _context = context;
            _upload = upload;
        }

        // GET: AddToYourInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddToYourInformation.ToListAsync());
        }

        // GET: AddToYourInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addToYourInformation = await _context.AddToYourInformation
                .FirstOrDefaultAsync(m => m.ID == id);
            if (addToYourInformation == null)
            {
                return NotFound();
            }

            return View(addToYourInformation);
        }

        // GET: AddToYourInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Page(int id)
        {
            var data = _context.AddToYourInformation.SingleOrDefault(ai => ai.ID==id);
            return View(data);
        }
        public IActionResult AddToYourInformations()
        {
            return View();
        }
        public IActionResult StudiesAndResearch()
        {
            var data = _context.AddToYourInformation.Where(ai => ai.AddToYourInformationType == Enums.AddToYourInformationType.StudiesAndResearch).ToList();
            return View(data);
        }

        public IActionResult TranslatedArticles()
        {
            var data = _context.AddToYourInformation.Where(ai => ai.AddToYourInformationType == Enums.AddToYourInformationType.TranslatedArticles).ToList();
            return View(data);
        }

        public IActionResult Articles()
        {
            var data = _context.AddToYourInformation.Where(ai => ai.AddToYourInformationType == Enums.AddToYourInformationType.Articles).ToList();
            return View(data);
        }
        // POST: AddToYourInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddToYourInformation addToYourInformation, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "CooperationAndPartners");
                    addToYourInformation.Image = imagepath;
                }
                _context.Add(addToYourInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addToYourInformation);
        }

        // GET: AddToYourInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addToYourInformation = await _context.AddToYourInformation.FindAsync(id);
            if (addToYourInformation == null)
            {
                return NotFound();
            }
            return View(addToYourInformation);
        }

        // POST: AddToYourInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,AddToYourInformation addToYourInformation)
        {
            if (id != addToYourInformation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addToYourInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddToYourInformationExists(addToYourInformation.ID))
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
            return View(addToYourInformation);
        }

        // GET: AddToYourInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addToYourInformation = await _context.AddToYourInformation
                .FirstOrDefaultAsync(m => m.ID == id);
            if (addToYourInformation == null)
            {
                return NotFound();
            }

            return View(addToYourInformation);
        }

        // POST: AddToYourInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addToYourInformation = await _context.AddToYourInformation.FindAsync(id);
            _context.AddToYourInformation.Remove(addToYourInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddToYourInformationExists(int id)
        {
            return _context.AddToYourInformation.Any(e => e.ID == id);
        }
    }
}
