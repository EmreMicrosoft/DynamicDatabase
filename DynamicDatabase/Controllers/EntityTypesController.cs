using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DynamicDatabase.Data.Access;
using DynamicDatabase.Data.Entities;

namespace DynamicDatabase.Controllers
{
    public class EntityTypesController : Controller
    {
        private readonly RepositoryContext _context;

        public EntityTypesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: EntityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityTypes.ToListAsync());
        }

        // GET: EntityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityType = await _context.EntityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityType == null)
            {
                return NotFound();
            }

            return View(entityType);
        }

        // GET: EntityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,IsActive")] EntityType entityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityType);
        }

        // GET: EntityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityType = await _context.EntityTypes.FindAsync(id);
            if (entityType == null)
            {
                return NotFound();
            }
            return View(entityType);
        }

        // POST: EntityTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive")] EntityType entityType)
        {
            if (id != entityType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityTypeExists(entityType.Id))
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
            return View(entityType);
        }

        // GET: EntityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityType = await _context.EntityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityType == null)
            {
                return NotFound();
            }

            return View(entityType);
        }

        // POST: EntityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityType = await _context.EntityTypes.FindAsync(id);
            _context.EntityTypes.Remove(entityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityTypeExists(int id)
        {
            return _context.EntityTypes.Any(e => e.Id == id);
        }
    }
}
