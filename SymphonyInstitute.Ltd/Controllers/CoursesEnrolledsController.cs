using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SymphonyInstitute.Ltd.Models;

namespace SymphonyInstitute.Ltd.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class CoursesEnrolledsController : Controller
    {
        private readonly StudentDbContext _context;

        public CoursesEnrolledsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: CoursesEnrolleds
        public async Task<IActionResult> Index()
        {
            var studentDbContext = _context.CoursesEnrolled.Include(c => c.Courses).Include(c => c.Employee).Include(c => c.Payment).Include(c => c.Student);
            return View(await studentDbContext.ToListAsync());
        }

        // GET: CoursesEnrolleds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesEnrolled = await _context.CoursesEnrolled
                .Include(c => c.Courses)
                .Include(c => c.Employee)
                .Include(c => c.Payment)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesEnrolled == null)
            {
                return NotFound();
            }

            return View(coursesEnrolled);
        }

        // GET: CoursesEnrolleds/Create
        public IActionResult Create()
        {
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: CoursesEnrolleds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,CoursesId,StudentId,PaymentId,Labsession,RollNo")] CoursesEnrolled coursesEnrolled)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursesEnrolled);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", coursesEnrolled.CoursesId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", coursesEnrolled.EmployeeId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Id", coursesEnrolled.PaymentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", coursesEnrolled.StudentId);
            return View(coursesEnrolled);
        }

        // GET: CoursesEnrolleds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesEnrolled = await _context.CoursesEnrolled.FindAsync(id);
            if (coursesEnrolled == null)
            {
                return NotFound();
            }

            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", coursesEnrolled.CoursesId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", coursesEnrolled.EmployeeId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Id", coursesEnrolled.PaymentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", coursesEnrolled.StudentId);
            return View(coursesEnrolled);
        }

        // POST: CoursesEnrolleds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,CoursesId,StudentId,PaymentId,Labsession,RollNo")] CoursesEnrolled coursesEnrolled)
        {
            if (id != coursesEnrolled.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursesEnrolled);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesEnrolledExists(coursesEnrolled.Id))
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

            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", coursesEnrolled.CoursesId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id", coursesEnrolled.EmployeeId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Id", coursesEnrolled.PaymentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", coursesEnrolled.StudentId);
            return View(coursesEnrolled);
        }

        // GET: CoursesEnrolleds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesEnrolled = await _context.CoursesEnrolled
                .Include(c => c.Courses)
                .Include(c => c.Employee)
                .Include(c => c.Payment)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesEnrolled == null)
            {
                return NotFound();
            }

            return View(coursesEnrolled);
        }

        // POST: CoursesEnrolleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursesEnrolled = await _context.CoursesEnrolled.FindAsync(id);
            _context.CoursesEnrolled.Remove(coursesEnrolled);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesEnrolledExists(int id)
        {
            return _context.CoursesEnrolled.Any(e => e.Id == id);
        }
    }
}
