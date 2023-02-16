using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MigrateDBApp.Models;

namespace MigrateDBApp.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();
        public ActionResult Index()
        {
            db.Users.AddRange(new List<User>
            {
                new User{Name="Tom"},
                new User{Name="Alice"}
            });
            db.SaveChanges();
            return View(db.Users.ToList());
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
    }
}