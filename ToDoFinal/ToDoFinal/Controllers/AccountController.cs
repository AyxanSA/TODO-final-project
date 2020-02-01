
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ToDoFinal.Models;
using ToDoFinal.MyData;

namespace ToDoFinal.Controllers
{
    public class AccountController : Controller
    {
         DBaza db = new DBaza();
        // GET: Accaunt
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registr(User user, string Confirm)
        {
            if (ModelState.IsValid)
            {
                var haveUser = db.Users.Any(u => u.Email == user.Email);

                if (!haveUser && user.Password == Confirm)
                {
                    user.Password = Crypto.HashPassword(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }


            }
            return View();
       
        }



        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {


            if (ModelState.IsValid)
            {
                var reqUser = db.Users.Where(e => e.Email == Email).SingleOrDefault();

                if (reqUser != null)
                {
                    
                        var secureUser = Crypto.VerifyHashedPassword(reqUser.Password, Password);
                        if (secureUser)
                        {
                            
                            Session["UserId"] = reqUser.Id;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.LoginMsg = "Şifrə və ya email yalnışdır";
                        }


                }
            
            }
         
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }

}
