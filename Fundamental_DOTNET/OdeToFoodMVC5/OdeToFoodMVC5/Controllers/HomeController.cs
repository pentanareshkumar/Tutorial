using OdeToFoodMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OdeToFoodMVC5.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodMVC5Db _db = new OdeToFoodMVC5Db();

        public ActionResult AutoComplete(string term)
        {
            var model = _db.Restaurants
                           .Where(r => r.Name.StartsWith(term))
                           .Take(10)
                           .Select(r => new
                           {
                               label = r.Name
                           });
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [OutputCache(CacheProfile="Long",VaryByHeader="X-Requested-With",Location= OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null)
        {
            var model = _db.Restaurants
                            .OrderByDescending(r => r.Name)
                            .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                            .Select(r => new RestaurantListViewModel
                            {
                                Id = r.Id,
                                Name = r.Name,
                                City = r.City,
                                Country = r.Country,
                                CountOfReviews = r.Reviews.Count()
                            });
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}