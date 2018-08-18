using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnginerWebApplication.Data;
using EnginerWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EnginerWebApplication.Controllers
{
    public class InstructionController : Controller
    {
      
        private ApplicationDbContext _db;

        private UserManager<ApplicationUser> _userManager;

        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public InstructionController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }



        //[HttpGet]
        //public async Task<string> GetCurrentUserId()
        //{
        //    ApplicationUser usr = await GetCurrentUserAsync();
        //    return usr?.Id;
        //}

       // private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public IActionResult Add()
        {

            //ApplicationUser user = GetCurrentUserAsync();
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            //var user = _db.Users.SingleOrDefault(u => u.Id == User.Identity.Name);
            _db.Instructions.Add(new Instruction { User = user,Description ="",Name=""});
            _db.SaveChanges();
            return RedirectToAction("ShowAdminPanel","Home");
        }

        public IActionResult ShowAllInstruction()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            var instruction = user.Instructions;
            return View(user.Instructions);
        }

        //public IActionResult ChangeInstruction
    }
}