using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SymphonyInstitute.Ltd.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SymphonyInstitute.Ltd.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly StudentDbContext context;
        private readonly ILogger<AccountsController> logger;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration confg;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountsController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            StudentDbContext _context, ILogger<AccountsController> logger,
            IWebHostEnvironment env, IConfiguration confg,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.context = _context;
            this.logger = logger;
            this.env = env;
            this.confg = confg;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Checj()
        {
            return View();
        }

        public IActionResult StudentSignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StudentSignUp(Student student)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {

                    UserName = student.Email,
                    Email = student.Email
                };

                var result = await this._userManager.CreateAsync(user, student.Password);

                string ID = user.Id;

                if (!result.Succeeded)
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
                else
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    if (!string.IsNullOrEmpty(ID))
                    {


                        student.AspNetUsersId = ID;
                        student.Religionid = student.religion;
                        student.Qualificationid = student.Qualifications;
                        context.Student.Add(student);
                        context.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(token))
                    {
                        this.SendEmailNotification(user, token);
                        ViewBag.ErrorTitle = "Registeration successful";
                        ViewBag.ErrorMessage = "Before you can Login, please confirm your " +
                                "email, by clicking on the confirmation link we have emailed you";

                        return View("Registered", new Student());
                    }
                }
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {


            var result = await this._signInManager.PasswordSignInAsync(login.UserName, login.Password, false, true);

            if (result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Your account is not verified");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account has been locked");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password ");
            }

            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        private void SendEmailNotification(ApplicationUser user, string token)
        {
            string appDomain = this.confg.GetSection("Application:AppDomain").Value;
            //string confirmationLink = this.confg.GetSection("Application:EmailConfirmation").Value;
            var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userId = user.Id, token = token }, Request.Scheme);


            string to = user.Email;
            string subject = "Account Confirmation";

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = this.HtmlBody(user, appDomain + confirmationLink, token);
            mailMessage.From = new MailAddress("demo39150@gmail.com");
            mailMessage.IsBodyHtml = true;


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("demo39150@gmail.com", "Qwerty@12345");

            smtpClient.Send(mailMessage);
        }

        private string HtmlBody(ApplicationUser user, string link, string token)
        {
            string body = null;

            using (StreamReader reader = new StreamReader(this.env.WebRootPath + "/Template/EmailTemp.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("{subject}", user.UserName);
                body = body.Replace("{link}", string.Format(link, user.Id, token));
            }

            return body;
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.IsSuccess = true;
            }


            return View();
        }
        public IActionResult UserRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRole(UserRoles userRole)
        {
            var user = context.ApplicationUsers.FirstOrDefault(x => x.Id == userRole.UserId);

            //IdentityRole identityRole =new IdentityRole()
            //{
            //    Id = userRole.RoleId,
            var result = await _userManager.AddToRoleAsync(user, "SuperAdmin");

            if (result.Succeeded)
            {

                ModelState.AddModelError("", "Added Succesfully");
                //ViewBag.Error = "Successfully Role Added";
                //return View("Registered");
            }


            return View("UserRole");
        }



    }



}
