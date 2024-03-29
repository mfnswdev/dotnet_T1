using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using new_MVCmovie.Models;

namespace new_MVCmovie.Controllers
{
    [Authorize]

    public class StudioController : Controller
    {
        private readonly MvcMovieContext _context;

        public StudioController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Studio
        public async Task<IActionResult> Index()
        {
            return _context.Studio != null ?
                        View(await _context.Studio.ToListAsync()) :
                        Problem("Entity set 'MvcMovieContext.Studio'  is null.");
        }

        // GET: Studio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio
                .FirstOrDefaultAsync(m => m.StudioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // GET: Studio/Create
        [Authorize(Roles = "admin")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Studio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudioId,name,country,site")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studio);
        }

        // GET: Studio/Edit/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }
            return View(studio);
        }

        // POST: Studio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudioId,name,country,site")] Studio studio)
        {
            if (id != studio.StudioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioExists(studio.StudioId))
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
            return View(studio);
        }

        // GET: Studio/Delete/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio
                .FirstOrDefaultAsync(m => m.StudioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // POST: Studio/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studio == null)
            {
                return Problem("Entity set 'MvcMovieContext.Studio'  is null.");
            }
            var studio = await _context.Studio.FindAsync(id);
            if (studio != null)
            {
                _context.Studio.Remove(studio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudioExists(int id)
        {
            return (_context.Studio?.Any(e => e.StudioId == id)).GetValueOrDefault();
        }
    }
}
