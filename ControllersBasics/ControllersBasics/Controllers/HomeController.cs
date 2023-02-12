using ControllersBasics.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasics.Controllers
{
    public class HomeController : Controller
    {
        public string GetContext()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
        }
        public void GetContextResponse()
        {
            HttpContext.Response.Write("<h1>Hello, World!!!</h1>");
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            HttpContext.Response.Write("<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>");
        }
        public FilePathResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/Test.txt");
            // Тип файла - content-type
            //string file_type = "application/txt";
            string file_type = "application/octet-stream"; // Более универсальное указание типа файлов
            // Имя файла - необязательно
            string file_name = "Test.txt";
            return File(file_path, file_type, file_name);
        }
        public FileContentResult GetBytes()
        {
            // Путь к файлу
            string path = Server.MapPath("~/Files/Test.txt");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            // Тип файла - content-type
            string file_type = "application/txt";
            // Имя файла - необязательно
            string file_name = "Test.txt";
            return File(mas, file_type, file_name);
        }
        public FileStreamResult GetStream()
        {
            // Путь к файлу
            string path = Server.MapPath("~/Files/Test.txt");
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            // Тип файла - content-type
            string file_type = "application/txt";
            // Имя файла - необязательно
            string file_name = "Test.txt";
            return File(fs, file_type, file_name);
        }
        public string GetData()
        {
            string id = HttpContext.Request.Cookies["id"].Value;
            var val = Session["name"];
            return val.ToString();
            //return id.ToString();
        }
        public ViewResult Index()
        {
            //ViewData["Head"] = "Hello World!";
            Session["name"] = "Tom";
            HttpContext.Response.Cookies["id"].Value = "ca-4353w";
            ViewBag.Head = "Hello World!";
            ViewBag.Fruit = new List<string>
            {
                "apple", "pear", "cherry"
            };
            return View(); // new ViewResult
        }
        public ActionResult GetImage() 
        {
            string path = "~/Content/Images/04.jpg";
            return new ImageResult(path);
        }
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }
        public RedirectResult GetVoid()
        {
            //return Redirect("/Home/Contact"); // временная переадресация
            return RedirectPermanent("/Home/Contact"); // постоянная переадресация
        }
        // применение нескольких видов переадресации
        public ActionResult GetVoid_(int id)
        {
            if (id > 3)
            {
                return Redirect("/Home/Contact");
            }
            return View("About");
        }
        // применение переадресации по маршруту
        public ActionResult GetVoidRoute(int id)
        {
            if (id > 3)
            {
                //return RedirectToRoute(new { controller = "Home", action = "Contact" });
                return RedirectToAction("Square", "Home", new { a = 10, h = 12 }); // переадресация с помощью перегруженого метода
                                                                                   // (1 параметр - метод, 2й параметр - контроллер, 3й параметр - входные значения метода)
            }
            return View("About");
        }
        // Применение статусных кодов
        public ActionResult GetVoidCode(int id)
        {
            if (id > 3)
            {
                //return new HttpStatusCodeResult(404);
                //return HttpNotFound();
                return new HttpUnauthorizedResult();
            }
            return View("About");
        }
        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public string PostBook() 
        {
            string title = Request.Form["title"];
            string author = Request.Form["author"];
            return title + " " + author;
        }
        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }
        public string GetId(int id)
        {
            return id.ToString();
        }

        private ActionResult About()
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