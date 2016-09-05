using PAccountant.Model.View.Managers.Abstract;
using PAccountant.Model.View.Managers.StaticClasses;
using PAccountant.Model.View.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        static AuthorizationManager authorizationManager;
        static AuthorizationController()
        {
            authorizationManager = DIManager.AuthorizationManager;
        }
        // GET: Authorization
        public ActionResult LogIn()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LoginModel model)
        {
            if (authorizationManager.Login(model))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Registration(RegisterModel model)
        {
            if (authorizationManager.Registration(model))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "User is already exists or not all data is inputed");
                return View();
            }
        }

        public ActionResult SignOut()
        {
            authorizationManager.LogOff();
            return RedirectToAction("LogIn");
        }
    }
}