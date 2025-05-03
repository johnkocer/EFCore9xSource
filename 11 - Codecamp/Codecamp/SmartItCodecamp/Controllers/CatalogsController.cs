using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartItCodecamp.Data;
using SmartItCodecamp.Models;

namespace SmartItCodecamp.Controllers
{
    public class CatalogsController : Controller
    {
        private readonly DataContext _context;

        public CatalogsController(DataContext context)
        {
            _context = context;
        }

        // GET: Catalogs
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Catalog.Include(c => c.Course).Include(c => c.Instructor);
            return View(await dataContext.ToListAsync());
        }

        // GET: Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // GET: Catalogs/Create
        public IActionResult Create()
        {
            // Create a new Catalog with default values
            var catalog = new Catalog
            {
                StartDate = DateTime.Today
            };
            
            // Ensure dropdown has selections
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FullName");
            return View(catalog);
        }

        // POST: Catalogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Catalog catalog)
        {
            try
            {
                // Remove custom validation as it might be interfering with model binding
                ModelState.Remove("Instructor");
                ModelState.Remove("Course");
                
                if (ModelState.IsValid)
                {
                    // Initialize RowVersion to an empty array; it will be populated by the database
                    catalog.RowVersion = Array.Empty<byte>();
                    _context.Add(catalog);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Add a single clear error message
                ModelState.AddModelError(string.Empty, $"Error creating catalog: {ex.Message}");
            }
            
            // If we got this far, something failed, redisplay form
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", catalog.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FullName", catalog.InstructorId);
            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog.SingleOrDefaultAsync(m => m.Id == id);
            if (catalog == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", catalog.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName", catalog.InstructorId);
            return View(catalog);
        }

        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstructorId,CourseId,Name,Tuition,StartDate,RowVersion")] Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", catalog.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName", catalog.InstructorId);
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalog = await _context.Catalog.SingleOrDefaultAsync(m => m.Id == id);
            if (catalog != null)
            {
                _context.Catalog.Remove(catalog);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
            return _context.Catalog.Any(e => e.Id == id);
        }
    }
}
