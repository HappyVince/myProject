
using Cookye.Models;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Users.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            Personne personne = null;
            if (Authentifie)
            {
                using (var db = new Model1())
                {
                    personne = (from p in db.Personnes
                                where p.Login == HttpContext.User.Identity.Name
                                select p).FirstOrDefault();
                }
            }
            return View(personne);
        }
        [HttpPost]
        public ActionResult Index(Personne personne)
        {
            Personne perso = null;
            var Authentifie = false;
            ViewData["Authentifie"] = Authentifie;
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    perso = (from p in db.Personnes
                             where p.Login.Equals(personne.Login) && p.Password.Equals(personne.Password)
                             select p).FirstOrDefault();
                    if (perso != null)
                    {
                        FormsAuthentication.SetAuthCookie(perso.Login.ToString(), false);
                        Authentifie = true;
                        return Redirect("/");
                    }
                }
            }
            return View("Index", personne);
        }
        public ActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inscription(Personne personne)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    db.Personnes.Add(personne);
                    db.SaveChanges();
                }
                FormsAuthentication.SetAuthCookie(personne.Login.ToString(), true);
                return Redirect("/");
            }
            return View(personne);
        }
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}