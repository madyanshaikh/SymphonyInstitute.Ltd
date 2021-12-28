using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SymphonyInstitute.Ltd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    public class AdministrativeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly StudentDbContext context;

        public AdministrativeController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser>userManager, StudentDbContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.context = context;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = model.RoleName
            };

            IdentityResult result = await roleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Rolelist", "Administrative");

            }
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
       public IActionResult Rolelist ()
        {
            var role = roleManager.Roles;
            return View(role);
        }
  

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
          
            var getuser = userManager.Users;

            return View(getuser);
        }

        [HttpGet]
        public IActionResult GetEnrolledDetails()
        {
            var getEnrolledDetails = context.ViewStudentDetails.FromSqlRaw<ViewStudentDetails>("select * from View_StudentDetails").ToList();

            return View(getEnrolledDetails);
        }
     
    }
}
