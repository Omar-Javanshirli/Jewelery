using Jewelery.Filters;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLoginCustom]
    public class AdsController : Controller
    {
        // JeweleryEntities db = new JeweleryEntities();
        private readonly JeweleryEntities.JeweleryDbContext _context;

        public AdsController(JeweleryEntities.JeweleryDbContext context)
        {
            _context = context;
        }

        // GET: Crm/Ads
        public ActionResult Index()
        {
            
            List<Ad> ads = _context.Ads.Where(w => w.Status == 1).ToList();
            return View(ads);
        }

        public ActionResult Deny(int id)
        {
            Ad ad = _context.Ads.FirstOrDefault(f => f.Id == id);
            if (ad != null)
            {
                ad.Status = 3;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}