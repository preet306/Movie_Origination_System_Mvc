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
    public class Movie_detailsController : Controller
    {
        private readonly Movie_Origination_System_MvcContext _context;

        public Movie_detailsController(Movie_Origination_System_MvcContext context)
        {
            _context = context;
        }

        // GET: Movie_details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie_details.ToListAsync());
        }
        [Authorize]
        // GET: Movie_details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_details = await _context.Movie_details
                .FirstOrDefaultAsync(m => m.Movie_ID == id);
            if (movie_details == null)
            {
                return NotFound();
            }

            return View(movie_details);
        }
        [Authorize]
        // GET: Movie_details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Movie_ID,Movie_Name,Movie_Release_Date,Movie_Language,Movie_Running_Time")] Movie_details movie_details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie_details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie_details);
        }
        [Authorize]
        // GET: Movie_details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_details = await _context.Movie_details.FindAsync(id);
            if (movie_details == null)
            {
                return NotFound();
            }
            return View(movie_details);
        }

        // POST: Movie_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Movie_ID,Movie_Name,Movie_Release_Date,Movie_Language,Movie_Running_Time")] Movie_details movie_details)
        {
            if (id != movie_details.Movie_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Movie_detailsExists(movie_details.Movie_ID))
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
            return View(movie_details);
        }
        [Authorize]
        // GET: Movie_details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_details = await _context.Movie_details
                .FirstOrDefaultAsync(m => m.Movie_ID == id);
            if (movie_details == null)
            {
                return NotFound();
            }

            return View(movie_details);
        }
        [Authorize]
        // POST: Movie_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie_details = await _context.Movie_details.FindAsync(id);
            _context.Movie_details.Remove(movie_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Movie_detailsExists(int id)
        {
            return _context.Movie_details.Any(e => e.Movie_ID == id);
        }
    }
}
