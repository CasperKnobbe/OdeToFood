using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var model = restaurants;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "not used";

            var model = new AboutModel();
            model.Name = "Casper";
            model.Location = "Houten, Nederland";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        static OdeToFoodDB dB = new OdeToFoodDB();
        static List<Models.Restaurant> restaurants = dB.GetRestaurants();
    }
}