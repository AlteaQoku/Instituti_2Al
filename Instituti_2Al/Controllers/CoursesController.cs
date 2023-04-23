using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Instituti_2Al.Data;
using Instituti_2Al.Models;

namespace Instituti_2Al.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public CoursesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Course.Include(c => c.DeletedBy).Include(c => c.Person).Include(c => c.UpdatedBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(c => c.DeletedBy)
                .Include(c => c.Person)
                .Include(c => c.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["DeletedById"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Price,Content,Image,ImageFile,Featured,Deleted,Id,PersonId,CreatedOn,IsDeleted,DeletedById,UpdatedById,UpdatedOn")] Course course, IFormFile ImageFile)
        {
            
            if (ModelState.IsValid)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Img/", ImageFile.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                    stream.Close();

                }
                course.Image = ImageFile.FileName;
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeletedById"] = new SelectList(_context.Users, "Id", "Id", course.DeletedById);
            ViewData["PersonId"] = new SelectList(_context.Users, "Id", "Id", course.PersonId);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Id", course.UpdatedById);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["DeletedById"] = new SelectList(_context.Users, "Id", "Id", course.DeletedById);
            ViewData["PersonId"] = new SelectList(_context.Users, "Id", "Id", course.PersonId);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Id", course.UpdatedById);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Price,Content,Image,Featured,Deleted,Id,PersonId,CreatedOn,IsDeleted,DeletedById,UpdatedById,UpdatedOn")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["DeletedById"] = new SelectList(_context.Users, "Id", "Id", course.DeletedById);
            ViewData["PersonId"] = new SelectList(_context.Users, "Id", "Id", course.PersonId);
            ViewData["UpdatedById"] = new SelectList(_context.Users, "Id", "Id", course.UpdatedById);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(c => c.DeletedBy)
                .Include(c => c.Person)
                .Include(c => c.UpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Course == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Course'  is null.");
            }
            var course = await _context.Course.FindAsync(id);
            if (course != null)
            {
                _context.Course.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_context.Course?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
