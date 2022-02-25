using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinghBowlShop.Data;
using SinghBowlShop.Models;

namespace SinghBowlShop.Controllers
{
    public class BowlMakersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BowlMakersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BowlMakers
        public async Task<IActionResult> Index(string bowlType, string searchString)
        {
            // Use LINQ to get list of Types.
            IQueryable<string> TypeQuery = from m in _context.BowlMaker
                                           orderby m.Type
                                           select m.Type;

            var bowls = from m in _context.BowlMaker
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                bowls = bowls.Where(s => s.Type.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bowlType))
            {
                bowls = bowls.Where(x => x.Type == bowlType);
            }

            var bowlTypeVM = new BowlTypeViewModel
            {
                Type = new SelectList(await TypeQuery.Distinct().ToListAsync()),
                BowlMakers = await bowls.ToListAsync()
            };

            return View(bowlTypeVM);
        }

        // GET: BowlMakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlMaker = await _context.BowlMaker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bowlMaker == null)
            {
                return NotFound();
            }

            return View(bowlMaker);
        }

        // GET: BowlMakers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BowlMakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Size,Color,Price,Rating")] BowlMaker bowlMaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowlMaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowlMaker);
        }

        // GET: BowlMakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlMaker = await _context.BowlMaker.FindAsync(id);
            if (bowlMaker == null)
            {
                return NotFound();
            }
            return View(bowlMaker);
        }

        // POST: BowlMakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Size,Color,Price,Rating")] BowlMaker bowlMaker)
        {
            if (id != bowlMaker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowlMaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlMakerExists(bowlMaker.Id))
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
            return View(bowlMaker);
        }

        // GET: BowlMakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlMaker = await _context.BowlMaker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bowlMaker == null)
            {
                return NotFound();
            }

            return View(bowlMaker);
        }

        // POST: BowlMakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowlMaker = await _context.BowlMaker.FindAsync(id);
            _context.BowlMaker.Remove(bowlMaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlMakerExists(int id)
        {
            return _context.BowlMaker.Any(e => e.Id == id);
        }
    }
}
