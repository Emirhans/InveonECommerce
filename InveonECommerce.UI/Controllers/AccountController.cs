using InveonECommerce.Bussines.Abstract;
using InveonECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InveonECommerce.UI.ViewModels;
using System.Threading.Tasks;
using System.Web.Security;

namespace InveonECommerce.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
   
        public IUserRepository _userService;
       
        public AccountController(IUserRepository userService)
        {
            _userService = userService;
      
        }

        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(UserModel user) //Giriş Ekranı
        {
            if (_userService.userExist(user))
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index","Product");
            }
            else
            {
                ViewBag.message = "Geçersiz kullanıcı adı veya şifre!";
                return View();

            }
        }

        //Oturumu Sonlandır
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model) //Kayıt Ekranı
        {
            _userService.Create(model);
            ViewBag.message = "Kayıt Başarılı";
            return View();
        }

    }

   
}