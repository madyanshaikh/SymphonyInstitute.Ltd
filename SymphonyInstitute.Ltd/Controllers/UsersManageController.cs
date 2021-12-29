using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SymphonyInstitute.Ltd.Models;

namespace SymphonyInstitute.Ltd.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UsersManageController : Controller
    {
        private readonly StudentDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersManageController(StudentDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: UsersManage
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUsers.ToListAsync());
        }

        // GET: UsersManage/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // GET: UsersManage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersManage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUsers aspNetUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUser);
        }

        // GET: UsersManage/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.ApplicationUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }
            return View(aspNetUser);
        }

        // POST: UsersManage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (ApplicationUser aspNetUser)
        {


            var user = await userManager.FindByIdAsync(aspNetUser.Id);


            user.Email = aspNetUser.Email;
            user.UserName = aspNetUser.UserName;
            user.EmailConfirmed = aspNetUser.EmailConfirmed;
            user.PhoneNumber = aspNetUser.PhoneNumber;
            user.LockoutEnabled = aspNetUser.LockoutEnabled;
             user.AccessFailedCount = aspNetUser.AccessFailedCount;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(aspNetUser);
        }



        // GET: UsersManage/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // POST: UsersManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aspNetUser = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUsersExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}

