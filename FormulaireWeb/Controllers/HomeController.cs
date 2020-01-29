using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormulaireWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        static Model1 model = new Model1();
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetSupprimer()
        {
            return View("Supprimer");
        }


        [HttpPost]
        public ActionResult Supprimer(User p)
        {
            if (model.Users.Find(p.Id) != null)
            {
                model.Users.Remove(model.Users.Find(p.Id));
                model.SaveChanges();
                return View("Index");
            }
            return View("Supprimer", p);
        }









        public ActionResult GetAjouter()
        {
            ViewBag.count = Session["count"];
            return View("Ajouter");
        }


        [HttpPost]
        public ActionResult Ajouter(User p)
        {
            if (ModelState.IsValid)
            {
                model.Users.Add(p);
                model.SaveChanges();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                return View("Index");
            }
            return View("Ajouter",p);
        }


        public ActionResult List()
        {
            ViewBag.list = model.Users.ToList();
            return View();
        }


    }
}