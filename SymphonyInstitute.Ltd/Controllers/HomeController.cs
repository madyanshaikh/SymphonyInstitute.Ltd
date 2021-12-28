using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SymphonyInstitute.Ltd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        StudentDbContext context;



        public HomeController(ILogger<HomeController> logger, StudentDbContext _context)
        {
            _logger = logger;
            this.context = _context;
        }

        public IActionResult Index()
        {
            return View();        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
