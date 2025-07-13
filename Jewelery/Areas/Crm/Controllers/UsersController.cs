using Jewelery.Filters;
using Jewelery.Models;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLoginCustom]
    public class UsersController : Controller
    {
        JeweleryEntities db = new JeweleryEntities();
        // GET: Crm/Users
        public ActionResult Index()
        {
            List<User> users = db.Users.Where(w => w.Status == true).ToList();

            return View(users);
        }
        public ActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(f => f.Id == id);
            user.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Change(int id , string Password)
        {
            User user = db.Users.FirstOrDefault(f => f.Id == id);
            if (user != null)
            {
                user.Password = Crypto.HashPassword(Password);
                db.SaveChanges();
            }
         
            return RedirectToAction("Index");
        }
    }
}