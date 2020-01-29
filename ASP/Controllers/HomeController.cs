using ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var list = new List<int>();
            list.Add(789);
            list.Add(789);
            list.Add(789);
            ViewData["list"] = list;
            ViewBag.list = list;
            return View();
        }

        public ActionResult Data(int? id)
        {
            var datas = new MaDonnee() { Integer = id, NomPage = "Test" };

            return View("Data", datas);
        }
    }
}