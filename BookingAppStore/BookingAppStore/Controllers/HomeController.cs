using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingAppStore.Models;

namespace BookingAppStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            var books = db.Books;
            ViewBag.Message = "Это частичное представление";
            //ViewBag.Books = books;

            SelectList authors = new SelectList(db.Books, "Author", "Name");
            ViewBag.Authors = authors;
            return View(books);
        }

        [HttpPost]
        public string GetForm(string[] countries)
        {
            string result = "";
            foreach (string c in countries)
            {
                result += c;
                result += ";";
            }
            return "Вы выбрали: " + result;
        }
        //public string GetForm(string author)
        //{
        //    return author;
        //}
        //public bool GetForm(bool set)
        //{
        //    return set;
        //}
        //public string GetForm(string color)
        //{
        //    return color;
        //}


        public ActionResult GetList()
        {
            string[] state = new string[] { "Belarus", "USA", "Canada", "France" };
            return PartialView(state);
        }

        public ActionResult BookIndex()
        {
            var books = db.Books;
            //ViewBag.Books = books;
            return View(books);
        }
        [HttpGet]
        public ActionResult Buy(int id) 
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в базе данных все изменения
            db.SaveChanges();
            return "Спасибо, " + purchase.Person + ", за покупку!";
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