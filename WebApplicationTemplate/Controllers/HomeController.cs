using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using WebApplicationTemplate.Models;

namespace WebApplicationTemplate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Singin()
        {
            return View();
        }


        GR95Entities db = new GR95Entities();



        [HttpPost]
        public ActionResult Register(REGISTRATION user)
        {
            try
            {
                db.REGISTRATION.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index","Home");

            }
            catch
            {
                return View();
            }
        }



        [HttpPost]
        public ActionResult Singin(REGISTRATION userr)
        {
            bool result= IsValid(userr.EMAIL, userr.PASSWORD);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Login Failed";
            }
            return View(userr);
        }



        private bool IsValid(string email,string password)
        {
            bool IsValid = false;
            var user = db.REGISTRATION.FirstOrDefault(u => u.EMAIL == email);
            if (user != null)
            {
                if (user.PASSWORD == password)
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }
}