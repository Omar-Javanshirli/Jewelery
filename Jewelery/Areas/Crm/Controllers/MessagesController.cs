using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelery.Filters;
using Jewelery.Models;
namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLogin]
    public class MessagesController : Controller
    {
        JeweleryEntities db = new JeweleryEntities();
        // GET: Crm/Messages
        public ActionResult Index()
        {
            List<Message> read = db.Messages.Where(w => w.IsReaden == false).ToList();
            read.ForEach(f => f.IsReaden = true);
            db.SaveChanges();
            List<Message> messages = db.Messages.Where(w=>w.Status == true).OrderBy(o => o.Id).ToList();
            return View(messages);
        }

        public ActionResult Delete(int id)
        {
            Message message = db.Messages.FirstOrDefault(f => f.Id == id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}