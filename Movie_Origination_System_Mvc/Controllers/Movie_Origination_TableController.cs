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
    public class Movie_Origination_TableController : Controller
    {
        private readonly Movie_Origination_System_MvcContext _context;

        public Movie_Origination_TableController(Movie_Origination_System_MvcContext context)
        {
            _context = context;
        }

        // GET: Movie_Origination_Table
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie_Origination_Table.ToListAsync());
        }

        // GET: Movie_Origination_Table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_Origination_Table = await _context.Movie_Origination_Table
                .FirstOrDefaultAsync(m => m.Movie_Origination_ID == id);
            if (movie_Origination_Table == null)
            {
                return NotFound();
            }

            return View(movie_Origination_Table);
        }
        [Authorize]
        // GET: Movie_Origination_Table/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie_Origination_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Movie_Origination_ID,Movie_ID,Movie_Producer_ID,Movie_Director_ID")] Movie_Origination_Table movie_Origination_Table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie_Origination_Table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie_Origination_Table);
        }
        [Authorize]
        // GET: Movie_Origination_Table/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_Origination_Table = await _context.Movie_Origination_Table.FindAsync(id);
            if (movie_Origination_Table == null)
            {
                return NotFound();
            }
            return View(movie_Origination_Table);
        }

        // POST: Movie_Origination_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Movie_Origination_ID,Movie_ID,Movie_Producer_ID,Movie_Director_ID")] Movie_Origination_Table movie_Origination_Table)
        {
            if (id != movie_Origination_Table.Movie_Origination_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie_Origination_Table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Movie_Origination_TableExists(movie_Origination_Table.Movie_Origination_ID))
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
            return View(movie_Origination_Table);
        }
        [Authorize]
        // GET: Movie_Origination_Table/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie_Origination_Table = await _context.Movie_Origination_Table
                .FirstOrDefaultAsync(m => m.Movie_Origination_ID == id);
            if (movie_Origination_Table == null)
            {
                return NotFound();
            }

            return View(movie_Origination_Table);
        }

        // POST: Movie_Origination_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie_Origination_Table = await _context.Movie_Origination_Table.FindAsync(id);
            _context.Movie_Origination_Table.Remove(movie_Origination_Table);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Movie_Origination_TableExists(int id)
        {
            return _context.Movie_Origination_Table.Any(e => e.Movie_Origination_ID == id);
        }
    }
}
