﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    public class BreakfastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreakfastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Breakfasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Breakfasts.ToListAsync());
        }

        // GET: Breakfasts/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfasts
                .FirstOrDefaultAsync(m => m.Date == id);
            if (breakfast == null)
            {
                return NotFound();
            }

            return View(breakfast);
        }

        // GET: Breakfasts/Overview
        public IActionResult Overview()
        {
            return View();
        }

        // GET: Breakfasts/Overview
        public async Task<IActionResult> AllOverview()
        {
            return View(await _context.RoomsCheckedIn.ToListAsync());
        }

        // GET: Breakfasts/Expected
        public async Task<IActionResult> Expected()
        {
            return View(await _context.Breakfasts.Where(b => b.Date == DateTime.Today).FirstOrDefaultAsync());
        }

        //GET: Breakfasts/Expected
        public async Task<IActionResult> AllExpected()
        {
            return View(await _context.Breakfasts.ToListAsync());
        }

        // POST: Breakfasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Children,Adults,Date")] Breakfast breakfast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breakfast);
        }

        // GET: Breakfasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfasts.FindAsync(id);
            if (breakfast == null)
            {
                return NotFound();
            }
            return View(breakfast);
        }

        // POST: Breakfasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Children,Adults,Date")] Breakfast breakfast)
        {
            if (id != breakfast.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastExists(breakfast.Date))
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
            return View(breakfast);
        }

        // GET: Breakfasts/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfasts
                .FirstOrDefaultAsync(m => m.Date == id);
            if (breakfast == null)
            {
                return NotFound();
            }

            return View(breakfast);
        }

        // POST: Breakfasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var breakfast = await _context.Breakfasts.FindAsync(id);
            _context.Breakfasts.Remove(breakfast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastExists(DateTime id)
        {
            return _context.Breakfasts.Any(e => e.Date == id);
        }
    }
}
