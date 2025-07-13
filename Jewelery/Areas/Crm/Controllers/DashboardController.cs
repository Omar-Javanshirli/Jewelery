using Jewelery.Areas.Crm.Data;
using Jewelery.Filters;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Areas.Crm.Controllers
{
    [AuthLoginCustom]
    public class DashboardController(IWebHostEnvironment env) : Controller
    {
        private readonly IWebHostEnvironment env = env;
        JeweleryEntities db = new JeweleryEntities();

        // GET: Crm/Dashboard
        public ActionResult Index()
        {
            DashboardVM data = new DashboardVM();
            data.Ads = db.Ads.Where(w => w.Status == 2).OrderByDescending(o => o.PublishDate).ToList();
            data.TotalAds = db.Ads.Count();
            data.ActiveAds = db.Ads.Where(w => w.Status == 1).Count();
            data.WaitingAds = db.Ads.Where(w => w.Status == 2).Count();
            data.NewMessages = db.Messages.Where(w => w.IsReaden == false).Count();
            data.TotalUsers = db.Users.Count();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            AdminEdit data = new AdminEdit();
            data.Ad = db.Ads.FirstOrDefault(f => f.Id == id && f.Status != 3);
            if (data.Ad != null)
            {
                data.menuItems = db.MenuItemLanguages.Where(w => w.MenuItem.Status == true && w.LangId == 1).ToList();
                data.menuCategories =
                    db.CategoryLanguages.Where(w => w.Category.Status == true && w.LangId == 1).ToList();
                data.subCategories = db.SubCategoryLanguages.Where(w => w.SubCategory.Status == true && w.LangId == 1)
                    .ToList();
                data.subSubCategories = db.SubSubCategoryLanguages
                    .Where(w => w.SubSubCategory.Status == true && w.LangId == 1).ToList();

                return View(data);
            }

            return RedirectToAction("Index");
        }

        //TODO IFromFile ucun islemeye biler
        public ActionResult Update(int id, Ad ad, List<IFormFile> Images)
        {
            Ad old = db.Ads.FirstOrDefault(f => f.Id == id);
            if (old != null)
            {
                old.Title = ad.Title;
                old.CategoryId = ad.CategoryId;
                old.Code = ad.Code;
                old.Description = ad.Description;
                old.DiamondCarat = ad.DiamondCarat;
                old.GoldCarat = ad.GoldCarat;
                old.IsNew = ad.IsNew;
                old.Status = 2;
                old.MenuId = ad.MenuId;
                old.SubCategoryId = ad.SubCategoryId;
                old.SubSubCategoryId = ad.SubSubCategoryId;
                if (ad.Price < old.Price)
                {
                    decimal oldPrice = old.Price;
                    old.Price = ad.Price;
                    old.OldPrice = oldPrice;
                }
                else
                {
                    old.Price = ad.Price;
                }

                old.Weight = ad.Weight;

                ad.PublishDate = DateTime.UtcNow.AddHours(4);


                db.SaveChanges();
                if (Images.Count > 0)
                {
                    int count = 1;
                    foreach (var Image in Images)
                    {
                        if (Image != null)
                        {
                            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Image.FileName.Replace(" ", "");
                            string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), filename);
                            Image.SaveAs(path);
                            AdImage adImage = new AdImage();
                            adImage.AdId = ad.Id;
                            adImage.Status = true;
                            adImage.Image = filename;
                            if (count == 1)
                            {
                                adImage.IsMain = true;
                            }
                            else
                            {
                                adImage.IsMain = false;
                            }

                            db.AdImages.Add(adImage);


                            count++;
                        }
                    }

                    db.SaveChanges();
                }
            }

            return RedirectToAction("edit", "dashboard", new { Area = "crm", id = id });
        }

        public ActionResult ImageDelete(int id)
        {
            AdImage image = db.AdImages.FirstOrDefault(f => f.Id == id);
            if (image != null)
            {
                db.AdImages.Remove(image);
                db.SaveChanges();
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Allow(int id)
        {
            Ad ad = db.Ads.FirstOrDefault(f => f.Id == id && f.Status == 2);
            if (ad != null)
            {
                ad.Status = 1;
                db.SaveChanges();
            }

            return RedirectToAction("index", "dashboard", new { Area = "crm" });
        }

        public ActionResult Deny(int id)
        {
            Ad ad = db.Ads.FirstOrDefault(f => f.Id == id && f.Status == 2);
            if (ad != null)
            {
                ad.Status = 3;
                db.SaveChanges();
            }

            return RedirectToAction("index", "dashboard", new { Area = "crm" });
        }
    }
}