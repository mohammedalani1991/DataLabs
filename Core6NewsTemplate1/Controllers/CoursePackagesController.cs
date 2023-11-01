using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOS.Data;
using WebOS.Models;

namespace WebOS.Controllers
{
    public class CoursePackagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;


        public CoursePackagesController(UserManager<ApplicationUser> userMrg, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userMrg;
        }

        // GET: CoursePackages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CoursePackage.Include(c => c.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CoursePackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoursePackage == null)
            {
                return NotFound();
            }

            var coursePackage = await _context.CoursePackage
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursePackage == null)
            {
                return NotFound();
            }

            return View(coursePackage);
        }

        // GET: CoursePackages/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: CoursePackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArName,EnName,ApplicationUserId,StartingDate,EndingDate,DateOfRecord,TotalMinutes,Image,IntroductoryVideo,Flyer,FilePdf,Effort,IsPaid,CourseFees,IsAdminApproved,IsFeatured,Overview,Introduction,LearningOutcomes,Requirements,Tags,Speciality,TargetStudents,ImportantDates,Language,IsPrerecorded,IsDeleted,Ishidden,IsReported,LiveStreamLink")] CoursePackage coursePackage)
        {
            if (ModelState.IsValid)
            {
                coursePackage.DateOfRecord=DateTime.Now;
                coursePackage.ApplicationUserId= _userManager.GetUserId(User);
                

                _context.Add(coursePackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", coursePackage.ApplicationUserId);
            return View(coursePackage);
        }

        // GET: CoursePackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoursePackage == null)
            {
                return NotFound();
            }

            var coursePackage = await _context.CoursePackage.FindAsync(id);
            if (coursePackage == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", coursePackage.ApplicationUserId);
            return View(coursePackage);
        }

        // POST: CoursePackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArName,EnName,ApplicationUserId,StartingDate,EndingDate,DateOfRecord,TotalMinutes,Image,IntroductoryVideo,Flyer,FilePdf,Effort,IsPaid,CourseFees,IsAdminApproved,IsFeatured,Overview,Introduction,LearningOutcomes,Requirements,Tags,Speciality,TargetStudents,ImportantDates,Language,IsPrerecorded,IsDeleted,Ishidden,IsReported,LiveStreamLink")] CoursePackage coursePackage)
        {
            if (id != coursePackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursePackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursePackageExists(coursePackage.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", coursePackage.ApplicationUserId);
            return View(coursePackage);
        }

        // GET: CoursePackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoursePackage == null)
            {
                return NotFound();
            }

            var coursePackage = await _context.CoursePackage
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursePackage == null)
            {
                return NotFound();
            }

            return View(coursePackage);
        }

        // POST: CoursePackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoursePackage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CoursePackage'  is null.");
            }
            var coursePackage = await _context.CoursePackage.FindAsync(id);
            if (coursePackage != null)
            {
                _context.CoursePackage.Remove(coursePackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursePackageExists(int id)
        {
          return _context.CoursePackage.Any(e => e.Id == id);
        }
    }
}
