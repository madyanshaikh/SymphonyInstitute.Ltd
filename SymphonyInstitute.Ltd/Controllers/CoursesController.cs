using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SymphonyInstitute.Ltd.Models;

namespace SymphonyInstitute.Ltd.Controllers
{
    public class CoursesController : Controller
    {
        private readonly StudentDbContext context;
        //public string Search { get; set; }
        public CoursesController(StudentDbContext _context)
        {
            context = _context;
        }


        // GET: Courses;2
        public async Task<IActionResult> Index()
        {
            return View(await context.Courses.ToListAsync());
        }
        public IActionResult CoursesCart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CoursesCart(Courses courses)
        {
            var userID = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("UserId")).Value;
            var user = context.Student.FirstOrDefault(x => x.AspNetUsersId.Equals(userID));
            //var facultyobj = new Employee();

            var faculty = context.Employee.FirstOrDefault();
            var pay = context.Payment.FirstOrDefault();
            var coursesUser = new CoursesEnrolled()
            {

                CoursesId = courses.Id,
                StudentId = user.Id,
                EmployeeId = faculty.Id,
                PaymentId = pay.Id


            };




            context.CoursesEnrolled.Add(coursesUser);


            context.SaveChanges();

            return View();
        }
        public IActionResult RollNoView()
        {
            return View();
        }
           [HttpGet]
        public IActionResult Getvoucher(Rollnumber roll)
        {


            //var userid = User.Claims.FirstOrDefault(x=>x.Type.Equals("UserId")).Value;
            //var student = context.Student.FirstOrDefault(x => x.AspNetUsersId.Equals(userid));
            //var courseEnrolled = context.CoursesEnrolled.FirstOrDefault(x => x.RollNo.Equals(roll.Search));

            //var roll = context.CoursesEnrolled.FirstOrDefault(x => x.RollNo.Equals(rollnumber.Search) );
            //var search = context.Rollnumbers.FirstOrDefault(x => x.Search.Equals(courseEnrolled.RollNo));
            var v = context.voucher.FromSqlRaw<Voucher>($"select * from View_Voucher where Rollno = '{roll.Search}'").ToList();
            

            if (v!= null)
            {


                return View(v);
            }
            else
            {
                ModelState.AddModelError("", "Work Hard Bro");



                //return View();
            }




            return View("RollNoView");

        }

        

    }
}
