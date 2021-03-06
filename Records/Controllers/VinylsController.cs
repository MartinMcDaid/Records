﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Records;
using Records.Models;

namespace Records.Controllers
{
    public class VinylsController : Controller
    {
        private readonly RecordsContext _context;

        public VinylsController(RecordsContext context)
        {
            _context = context;
        }

        // GET: Vinyls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vinyl.ToListAsync());
        }

        // GET: Vinyls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vinyl == null)
            {
                return NotFound();
            }

            return View(vinyl);
        }

        // GET: Vinyls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vinyls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Label,Artist,Title,ReleaseDate")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vinyl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vinyl);
        }

        // GET: Vinyls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl.FindAsync(id);
            if (vinyl == null)
            {
                return NotFound();
            }
            return View(vinyl);
        }

        // POST: Vinyls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Label,Artist,Title,ReleaseDate")] Vinyl vinyl)
        {
            if (id != vinyl.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinyl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinylExists(vinyl.ID))
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
            return View(vinyl);
        }

        // GET: Vinyls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyl
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vinyl == null)
            {
                return NotFound();
            }

            return View(vinyl);
        }

        // POST: Vinyls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vinyl = await _context.Vinyl.FindAsync(id);
            _context.Vinyl.Remove(vinyl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinylExists(string id)
        {
            return _context.Vinyl.Any(e => e.ID == id);
        }
    }
}
