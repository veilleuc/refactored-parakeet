using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using parakeet.Data;
using parakeet.Models;

namespace parakeet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            Design[] designs = _context.Designs.ToArray();

            // sort the designs by popularity
            // this will sort them from lowest to highest so must get last 5 designs

            Array.Sort(designs, delegate (Design d1, Design d2) {
               return d1.Popularitycounter.CompareTo(d2.Popularitycounter);
           });

            return View(designs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
