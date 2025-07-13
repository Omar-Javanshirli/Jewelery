using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Jewelery.Models;
namespace Jewelery.Areas.Crm.Controllers
{
    public class LoginCrmController : Controller
    {
        // GET: Manage/Login
        //public JsonResult Test()
        //{
        //    string pass = Crypto.HashPassword("Gold!2011");
        //    return Json(pass, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                //User user = db.Users.FirstOrDefault(u => u.Email == login.Email);
                if (login.Email == "admin@gold.az")
                {
                    if (System.Web.Helpers.Crypto.VerifyHashedPassword("ABGaYZ/sdH0kOFCFbNnmlAva9HQMP+YrjVIor4ETjXl1uqpPS+KRvlVhVuywLjQVZw==", login.Password))
                    {
                        Session["Admin"] = true;
                        Session["Logged"] = true;
                        return RedirectToAction("Index", "dashboard");
                    }
                }

                else
                {
                    ModelState.AddModelError("Summary", "E-poçt və ya Şifrə yanlışdır");
                }
            }
            return View(login);
        }
    }
}