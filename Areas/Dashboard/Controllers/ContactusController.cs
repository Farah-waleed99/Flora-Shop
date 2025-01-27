using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flora.Models;
using Master.Data;
using Microsoft.AspNetCore.Authorization;

namespace Flora.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ContactusController : Controller
    {
        private readonly AppDbContext _context;

        public ContactusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Contactus
        public async Task<IActionResult> Index()
        {
            return View(await _context.contactus.ToListAsync());
        }

        // GET: Dashboard/Contactus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.contactus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactus == null)
            {
                return NotFound();
            }

            var contactUs = await _context.contactus
                           .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: Dashboard/Contactus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Contactus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Message")] Contactus contactus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactus);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Your Message Sent Successfuly";
                return RedirectToAction(nameof(Create));
            }
            return View(contactus);
        }

        // GET: Dashboard/Contactus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.contactus.FindAsync(id);
            if (contactus == null)
            {
                return NotFound();
            }
            return View(contactus);
        }

        // POST: Dashboard/Contactus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Message")] Contactus contactus)
        {
            if (id != contactus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactusExists(contactus.Id))
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
            return View(contactus);
        }

        // GET: Dashboard/Contactus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.contactus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactus == null)
            {
                return NotFound();
            }

            return View(contactus);
        }

        // POST: Dashboard/Contactus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactus = await _context.contactus.FindAsync(id);
            if (contactus != null)
            {
                _context.contactus.Remove(contactus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactusExists(int id)
        {
            return _context.contactus.Any(e => e.Id == id);
        }
    }
}
