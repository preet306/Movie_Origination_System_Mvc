using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Origination_System_Mvc.Data;
using Movie_Origination_System_Mvc.Models;

namespace Movie_Origination_System_Mvc.Controllers
{
    public class Producer_detailsController : Controller
    {
        private readonly Movie_Origination_System_MvcContext _context;

        public Producer_detailsController(Movie_Origination_System_MvcContext context)
        {
            _context = context;
        }

        // GET: Producer_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producer_details.ToListAsync());
        }

        // GET: Producer_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer_details = await _context.Producer_details
                .FirstOrDefaultAsync(m => m.Movie_Producer_ID == id);
            if (producer_details == null)
            {
                return NotFound();
            }

            return View(producer_details);
        }
        [Authorize]
        // GET: Producer_details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producer_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Movie_Producer_ID,Movie_Producer_Name,Movie_Producer_Email,Movie_Producer_Mobile,Movie_Producer_Occupations")] Producer_details producer_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producer_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producer_details);
        }
        [Authorize]
        // GET: Producer_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer_details = await _context.Producer_details.FindAsync(id);
            if (producer_details == null)
            {
                return NotFound();
            }
            return View(producer_details);
        }

        // POST: Producer_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Movie_Producer_ID,Movie_Producer_Name,Movie_Producer_Email,Movie_Producer_Mobile,Movie_Producer_Occupations")] Producer_details producer_details)
        {
            if (id != producer_details.Movie_Producer_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producer_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Producer_detailsExists(producer_details.Movie_Producer_ID))
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
            return View(producer_details);
        }
        [Authorize]
        // GET: Producer_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer_details = await _context.Producer_details
                .FirstOrDefaultAsync(m => m.Movie_Producer_ID == id);
            if (producer_details == null)
            {
                return NotFound();
            }

            return View(producer_details);
        }

        // POST: Producer_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer_details = await _context.Producer_details.FindAsync(id);
            _context.Producer_details.Remove(producer_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Producer_detailsExists(int id)
        {
            return _context.Producer_details.Any(e => e.Movie_Producer_ID == id);
        }
    }
}
