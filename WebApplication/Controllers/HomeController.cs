using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            using (var context = new AnimalContext())
            {
                context.AnimalTypes.Add(new AnimalType()
                {
                    Id = 1,
                    MeanCost = 1,
                    Name = "test",
                    //EventDataValues = new List<EventData>()
                    //{

                    //}
                });
                context.SaveChanges();
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}