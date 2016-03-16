using OdeToFood.Filters;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index(string searchTerm = null)
        {
            //var model = from r in _db.Restaurants
            //            orderby r.Name descending
            //            select new RestaurantListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            var model = _db.Restaurants
                            .OrderByDescending(r => r.Name)
                            .Where(r=> searchTerm == null || r.Name.StartsWith(searchTerm))
                            .Select(r => new RestaurantListViewModel
                                    {
                                        Id = r.Id,
                                        Name = r.Name,
                                        City = r.City,
                                        Country = r.Country,
                                        CountOfReviews = r.Reviews.Count()
                                    });

            return View(model);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";
            //ViewBag.NareshMessage = "Hello Naresh, How are you ?";
            var model = new AboutModel();
            model.Name = "Naresh";
            model.Location = "Bangalore";
            return View(model);
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
