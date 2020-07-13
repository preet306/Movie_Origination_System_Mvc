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
    public class Director_detailsController : Controller
    {
        private readonly Movie_Origination_System_MvcContext _context;

        public Director_detailsController(Movie_Origination_System_MvcContext context)
        {
            _context = context;
        }

        // GET: Director_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Director_details.ToListAsync());
        }

        // GET: Director_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director_details = await _context.Director_details
                .FirstOrDefaultAsync(m => m.Movie_Director_ID == id);
            if (director_details == null)
            {
                return NotFound();
            }

            return View(director_details);
        }
        [Authorize]
        // GET: Director_details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Director_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Movie_Director_ID,Movie_Director_Name,Movie_Director_Email,Movie_Director_Mobile,Movie_Director_Occupations")] Director_details director_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(director_details);
        }
        [Authorize]
        // GET: Director_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director_details = await _context.Director_details.FindAsync(id);
            if (director_details == null)
            {
                return NotFound();
            }
            return View(director_details);
        }

        // POST: Director_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Movie_Director_ID,Movie_Director_Name,Movie_Director_Email,Movie_Director_Mobile,Movie_Director_Occupations")] Director_details director_details)
        {
            if (id != director_details.Movie_Director_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Director_detailsExists(director_details.Movie_Director_ID))
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
            return View(director_details);
        }
        [Authorize]
        // GET: Director_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director_details = await _context.Director_details
                .FirstOrDefaultAsync(m => m.Movie_Director_ID == id);
            if (director_details == null)
            {
                return NotFound();
            }

            return View(director_details);
        }

        // POST: Director_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director_details = await _context.Director_details.FindAsync(id);
            _context.Director_details.Remove(director_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Director_detailsExists(int id)
        {
            return _context.Director_details.Any(e => e.Movie_Director_ID == id);
        }
    }
}
