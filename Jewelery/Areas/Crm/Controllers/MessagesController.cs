using Jewelery.Filters;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLoginCustom]
    public class MessagesController : Controller
    {
        JeweleryEntities db = new JeweleryEntities();
        private readonly JeweleryEntities.JeweleryDbContext _context;

        public MessagesController(JeweleryEntities.JeweleryDbContext context)
        {
            _context = context;
        }

        // GET: Crm/Messages
        public ActionResult Index()
        {
            List<Message> read = _context.Messages.Where(w => w.IsReaden == false).ToList();
            read.ForEach(f => f.IsReaden = true);
            db.SaveChanges();
            List<Message> messages = _context.Messages.Where(w=>w.Status == true).OrderBy(o => o.Id).ToList();
            return View(messages);
        }

        public ActionResult Delete(int id)
        {
            Message message = _context.Messages.FirstOrDefault(f => f.Id == id);
            _context.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}