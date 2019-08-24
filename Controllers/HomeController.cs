using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Belt_exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Belt_exam.Controllers
{
    public class HomeController : Controller
    {

        private BeltContext dbContext;

        public HomeController(BeltContext context)
        {
            dbContext = context;
        }
        
        [HttpGet("home")]
        public IActionResult Index()
        {
            int? userSessionId = HttpContext.Session.GetInt32("user_id");
            if(userSessionId == null){
                System.Console.WriteLine("session id is null");
                return View("Register");
            }
            List<Act> allacts = dbContext.activities
            .Include(w=>w.Coordinator)
            .Include(w=>w.UsersAttending)
            .ThenInclude(a=>a.ThisUser)
            .OrderBy(e=>e.Date)
            .ToList();
            Wrapper newWrapper = new Wrapper();
            newWrapper.AllActs = allacts;
            ViewBag.AllActs = allacts;
            ViewBag.curruser = dbContext.users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("user_id"));
            return View();
        }

        [HttpGet("new")]
        public IActionResult NewAct()
        {
            int? userSessionId = HttpContext.Session.GetInt32("user_id");
            if(userSessionId == null){
                System.Console.WriteLine("session id is null");
                return View("Register");
            }
            return View();
        }


        [HttpGet("remove/{id}")]
        public IActionResult RemoveAct(int id)
        {
            int? userSessionId = HttpContext.Session.GetInt32("user_id");
            if(userSessionId == null){
                System.Console.WriteLine("session id is null");
                return View("Register");
            }
            Act ActtoRemove = dbContext.activities.FirstOrDefault(c=>c.ActId == id);
            dbContext.Remove(ActtoRemove);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost("processact")]
        public IActionResult ProcessAct(Act newAct)
        {
            if(ModelState.IsValid){
                if(newAct.Duration<1){
                    ModelState.AddModelError("Duration", "Duration cannot be negative");
                    return View("NewAct");
                }
                int? userSessionId = HttpContext.Session.GetInt32("user_id");
                User curruser = dbContext.users.FirstOrDefault(u=>u.UserId == userSessionId);
                newAct.Coordinator = curruser;
                dbContext.Add(newAct);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }else{
                return View("NewAct");
            }
        }





        [HttpGet("join/{id}")]
        public IActionResult Join(int id)
        {
            int? userSessionId = HttpContext.Session.GetInt32("user_id");
            if(userSessionId == null){
                System.Console.WriteLine("session id is null");
                return View("Register");
            }else{
                System.Console.WriteLine(id);
                User curruser = dbContext.users.FirstOrDefault(u=>u.UserId == userSessionId);
                Attending newAtt = new Attending();
                newAtt.ThisActId = id;
                newAtt.ThisUserId = (int)userSessionId;
                System.Console.WriteLine("***********************");
                System.Console.WriteLine((int)userSessionId);
                dbContext.Add(newAtt);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet("leave/{id}")]
        public IActionResult Leave(int id)
        {
            int? userSessionId = HttpContext.Session.GetInt32("user_id");
            if(userSessionId == null){
                System.Console.WriteLine("session id is null");
                return View("Register");
            }else{
                Attending attToRemove = dbContext.attendees.Where(a=>a.ThisUserId == userSessionId)
                .FirstOrDefault(a=>a.ThisActId == id);
                dbContext.attendees.Remove(attToRemove);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }











        [HttpGet("activity/{id}")]
        public IActionResult ActInfo(int id)
        {
            int? userSessionId = HttpContext.Session.GetInt32("user_id");
            if (userSessionId == null)
                {
                    return View("Register");
                }
            List<Act> allacts = dbContext.activities
            .Include(w=>w.Coordinator)
            .Include(w=>w.UsersAttending)
            .ThenInclude(a=>a.ThisUser)
            .OrderBy(e=>e.Date)
            .ToList();

            Wrapper newWrapper = new Wrapper();
            Act myAct = dbContext.activities.
            Include(a=>a.Coordinator).Include(a=>a.UsersAttending)
            .ThenInclude(a=>a.ThisUser)
            .FirstOrDefault(a=>a.ActId == id);
            newWrapper.OneAct = myAct;
            ViewBag.curractid = id;
            ViewBag.curract = myAct;
            ViewBag.curruser = dbContext.users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("user_id"));
            return View(newWrapper);
        }




        
        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult ProcessReg(User user)
        {
            if (ModelState.IsValid)
            {

                var userInDb = dbContext.users.FirstOrDefault(u => u.Email == user.Email);
                if (userInDb != null)
                {
                    ModelState.AddModelError("Email", "Duplicate Email");
                    return View("Register");
                }
                var input = user.Password;
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
                Console.WriteLine(isValidated);
                if(!isValidated){
                    ModelState.AddModelError("Password", "Must have a special, Number, uppercase, and lowercase");
                    return View("Register");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                System.Console.WriteLine(user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("user_id", user.UserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Register");
            }
        }






        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("processlog")]
        public IActionResult ProcessLogin(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if (result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Login");
                }
                else
                {
                    HttpContext.Session.SetInt32("user_id", userInDb.UserId);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                System.Console.WriteLine("Model State Not Valid");
                return View("Login");
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Register");
        }


    }
}
