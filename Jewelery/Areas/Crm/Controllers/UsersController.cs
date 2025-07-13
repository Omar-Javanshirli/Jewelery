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
        private readonly JeweleryEntities.JeweleryDbContext  _context;

        public UsersController(JeweleryEntities.JeweleryDbContext context)
        {
            _context = context;
        }

        // GET: Crm/Users
        public ActionResult Index()
        {
            List<User> users = _context.Users.Where(w => w.Status == true).ToList();

            return View(users);
        }
        public ActionResult Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(f => f.Id == id);
            user.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Change(int id , string Password)
        {
            User user = _context.Users.FirstOrDefault(f => f.Id == id);
            if (user != null)
            {
                user.Password = Crypto.HashPassword(Password);
                db.SaveChanges();
            }
         
            return RedirectToAction("Index");
        }
    }
}