using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Redo.Data;
using Redo.Models;

namespace Redo.Controllers
{
    public class FptClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FptClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FptClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.FptClass.ToListAsync());
        }

        // GET: FptClasses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fptClass = await _context.FptClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fptClass == null)
            {
                return NotFound();
            }

            return View(fptClass);
        }

        // GET: FptClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FptClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Teacher,OpenAt,UpdateAt,Status")] FptClass fptClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fptClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fptClass);
        }

        // GET: FptClasses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fptClass = await _context.FptClass.FindAsync(id);
            if (fptClass == null)
            {
                return NotFound();
            }
            return View(fptClass);
        }

        // POST: FptClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Teacher,OpenAt,UpdateAt,Status")] FptClass fptClass)
        {
            if (id != fptClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fptClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FptClassExists(fptClass.Id))
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
            return View(fptClass);
        }

        // GET: FptClasses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fptClass = await _context.FptClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fptClass == null)
            {
                return NotFound();
            }

            return View(fptClass);
        }

        // POST: FptClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var fptClass = await _context.FptClass.FindAsync(id);
            _context.FptClass.Remove(fptClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FptClassExists(long id)
        {
            return _context.FptClass.Any(e => e.Id == id);
        }
    }
}
