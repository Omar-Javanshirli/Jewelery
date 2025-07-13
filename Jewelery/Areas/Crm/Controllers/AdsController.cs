using Jewelery.Filters;
using Jewelery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLoginCustom]
    public class AdsController : Controller
    {
        JeweleryEntities db = new JeweleryEntities();
        // GET: Crm/Ads
        public ActionResult Index()
        {
            List<Ad> ads = db.Ads.Where(w => w.Status == 1).ToList();
            return View(ads);
        }

        public ActionResult Deny(int id)
        {
            Ad ad = db.Ads.FirstOrDefault(f => f.Id == id);
            if (ad != null)
            {
                ad.Status = 3;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}