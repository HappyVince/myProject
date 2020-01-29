using EntityFrameworkProject;
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
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            return View();
        }


        public ActionResult GetAcheter()
        {
            ViewBag.panier = (List<Item>)Session["panier"];
            if (ViewBag.panier == null)
            {
                return View("Index");
            }
            return View("Acheter");
        }


        [HttpPost]
        public ActionResult Acheter(Item p)
        {
            var sessionList = (List<Item>)Session["panier"];
            foreach (var itemCurr in sessionList)
            {
                if (itemCurr.Id == p.Id)
                {
                    sessionList.Remove(itemCurr);
                    Session["panier"] = sessionList;
                    return View("Index");
                }
            }
            return View("Acheter", p);
        }

        public ActionResult GetAjouterPanier()
        {
            ViewBag.panier = (List<Item>)Session["panier"];
            return View("AjouterPanier");
        }


        [HttpPost]
        public ActionResult AjouterPanier(Item p)
        {
            if (Session["panier"] == null)
            {
                Session["panier"] = new List<Item>();
            }

            if (p.Id != 0)
            {
                var sessionList = (List<Item>)Session["panier"];
                sessionList.Add(model.Items.Find(p.Id));
                Session["panier"] = sessionList;
                return View("Index");
            }
            return View("AjouterPanier", p);
        }





        [Authorize]

        public ActionResult GetAjouter()
        {
            ViewBag.count = Session["count"];
            return View("Ajouter");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Ajouter(Item p)
        {
            if (ModelState.IsValid)
            {
                model.Items.Add(p);
                model.SaveChanges();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                return View("Index");
            }
            return View("Ajouter",p);
        }


        public ActionResult List()
        {
            ViewBag.list = model.Items.ToList();
            return View();
        }

        public ActionResult ListPanier()
        {
            return View();
        }

    }
}