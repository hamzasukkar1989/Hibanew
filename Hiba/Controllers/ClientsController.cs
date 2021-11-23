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
using System.Globalization;
using System.Threading;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Hiba.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadFile _upload;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        readonly IWebHostEnvironment _webHostEnvironment;
        public ClientsController(ApplicationDbContext context, IUploadFile upload, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _upload = upload;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Clients
        public async Task<IActionResult> Client(int id)
        {
            ViewBag.align = "left";
            ViewBag.Title1 = "Our clients";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
                ViewBag.Title1 = "عملاؤنا";
            }
            var data = await _context.Clients.SingleOrDefaultAsync(c => c.ID == id);
            return View(data);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        public async Task<IActionResult> Clients()
        {
            ViewBag.Title1 = "Our clients";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "عملاؤنا";
            }
            var clients = await _context.Clients.Where(c=>c.Lang== cultureInfo.ToString()).ToListAsync();
            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string imagepath = await _upload.UploadFile(img, "Clients");
                    client.Image = imagepath;
                }
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Text,Image")] Client client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var client = await _context.Clients.FindAsync(id);

            //string path = _webHostEnvironment.WebRootPath;
            // path += client.Image.Replace("/", @"\");          


            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            string tets = _upload.DeleteFile(client.Image);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }
    }
}
