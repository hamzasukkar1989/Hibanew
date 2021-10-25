using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hiba.Data;
using Hiba.Models;

namespace Hiba.Controllers
{
    public class AddToYourInformationTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddToYourInformationTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddToYourInformationTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddToYourInformationTags.ToListAsync());
        }

        // GET: AddToYourInformationTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addToYourInformationTag = await _context.AddToYourInformationTags
                .Include(a => a.AddToYourInformations)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (addToYourInformationTag == null)
            {
                return NotFound();
            }

            return View(addToYourInformationTag);
        }

        // GET: AddToYourInformationTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddToYourInformationTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] AddToYourInformationTag addToYourInformationTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addToYourInformationTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addToYourInformationTag);
        }

        // GET: AddToYourInformationTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addToYourInformationTag = await _context.AddToYourInformationTags.FindAsync(id);
            if (addToYourInformationTag == null)
            {
                return NotFound();
            }
            return View(addToYourInformationTag);
        }

        // POST: AddToYourInformationTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] AddToYourInformationTag addToYourInformationTag)
        {
            if (id != addToYourInformationTag.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addToYourInformationTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddToYourInformationTagExists(addToYourInformationTag.ID))
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
            return View(addToYourInformationTag);
        }

        // GET: AddToYourInformationTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addToYourInformationTag = await _context.AddToYourInformationTags
                .FirstOrDefaultAsync(m => m.ID == id);
            if (addToYourInformationTag == null)
            {
                return NotFound();
            }

            return View(addToYourInformationTag);
        }

        // POST: AddToYourInformationTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addToYourInformationTag = await _context.AddToYourInformationTags.FindAsync(id);
            _context.AddToYourInformationTags.Remove(addToYourInformationTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddToYourInformationTagExists(int id)
        {
            return _context.AddToYourInformationTags.Any(e => e.ID == id);
        }
    }
}
