using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnginerWebApplication.Models;
using EnginerWebApplication.Data;
using Microsoft.AspNetCore.Identity;

namespace EnginerWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;

        private  ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {           
            _db = db;
        }


        public IActionResult ShowAdminPanel()
        {
            return View(_db.Instructions.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
