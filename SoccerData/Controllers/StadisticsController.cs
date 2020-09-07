using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerData.Data;
using SoccerData.Models;

namespace SoccerData.Controllers
{
    public class StadisticsController : Controller
    {
        private readonly SoccerDataContext _context;

        public StadisticsController(SoccerDataContext context)
        {
            _context = context;
        }

        // GET: Stadistics
        public async Task<IActionResult> Index(string searchString)
        {
            var stadistics = from m in _context.SoccerData
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                stadistics = stadistics.Where(s => s.home_team.Contains(searchString) || s.away_team.Contains(searchString));
            }
            return View(await stadistics.ToListAsync());
        }

        // GET: Stadistics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadistics = await _context.SoccerData
                .FirstOrDefaultAsync(m => m.id == id);
            if (stadistics == null)
            {
                return NotFound();
            }

            return View(stadistics);
        }

        // GET: Stadistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stadistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,league,teams_no,date,home_team,away_team,result,h_final,a_final,h_half,a_half,h1h,a1h,h2h,a2h")] Stadistics stadistics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stadistics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stadistics);
        }

        // GET: Stadistics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadistics = await _context.SoccerData.FindAsync(id);
            if (stadistics == null)
            {
                return NotFound();
            }
            return View(stadistics);
        }

        // POST: Stadistics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,league,teams_no,date,home_team,away_team,result,h_final,a_final,h_half,a_half,h1h,a1h,h2h,a2h")] Stadistics stadistics)
        {
            if (id != stadistics.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stadistics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StadisticsExists(stadistics.id))
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
            return View(stadistics);
        }

        // GET: Stadistics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadistics = await _context.SoccerData
                .FirstOrDefaultAsync(m => m.id == id);
            if (stadistics == null)
            {
                return NotFound();
            }

            return View(stadistics);
        }

        // POST: Stadistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stadistics = await _context.SoccerData.FindAsync(id);
            _context.SoccerData.Remove(stadistics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StadisticsExists(int id)
        {
            return _context.SoccerData.Any(e => e.id == id);
        }
    }
}
