using BussinessLogic.Infrastructure.Concrete;
using BussinessLogic.Managers.Abstract;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.Managers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.Model.View.Models.ClientModels;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        static AuthorizationManager _authorizationManager;
        static CryptographyManager _cryptoManager;
        static IAccountManager _accountManager;
        static AuthorizationController()
        {
            _authorizationManager = DIManager.AuthorizationManager;
            _cryptoManager = DIManager.CryptographyManager;
            _accountManager = DIManager.AccountManager;

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
            byte[] userPassword = _cryptoManager.EncodingString(model.Password);
            if (ValidationManager.modelIsValid(model)&& _accountManager.userExists(model.Name, userPassword)
                && _authorizationManager.Login(model.Name, userPassword))
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

            byte[] userPassword = _cryptoManager.EncodingString(model.Password);
            if (ValidationManager.modelIsValid(model) && !_accountManager.userExists(model.Name, userPassword)
                && _authorizationManager.Registration(model.Name, userPassword))
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
            _authorizationManager.LogOff();
            return RedirectToAction("LogIn");
        }


    }
}