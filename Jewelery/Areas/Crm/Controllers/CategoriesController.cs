using Jewelery.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLogin]
    public class CategoriesController : Controller
    {
        // GET: Crm/Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}