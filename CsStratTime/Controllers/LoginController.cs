using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSession.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
/*            Strat strat = new Strat(1, "rushb", "~/Images/UserStrat/1_rushb_de_inferno.png");
            Strat strat1 = new Strat(1, "slow-mid", "~/Images/UserStrat/1_slow-mid_de_mirage.png");
            using (var db = new Model1())
            {
                db.Strats.Add(strat1);
                db.Strats.Add(strat);
                db.SaveChanges();
            }*/
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            if (Authentifie == false)
            {
                ViewData["Authentifie"] = Authentifie;
            }
            Utilisateur utilisateur = null;
            if (Authentifie)
            {
                ViewData["Authentifie"] = Authentifie;
                using (var db = new Model1())
                {
                    utilisateur = (from p in db.Utilisateurs
                                where p.Login == HttpContext.User.Identity.Name
                                select p).FirstOrDefault();
                }
            }
            return View(utilisateur);
        }
        [HttpPost]
        public ActionResult Index(Utilisateur utilisateur)
        {
            Utilisateur perso = null;
            var Authentifie = false;
            ViewData["Authentifie"] = Authentifie;
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    perso = (from p in db.Utilisateurs
                             where p.Login.Equals(utilisateur.Login) && p.Password.Equals(utilisateur.Password)
                             select p).FirstOrDefault();
                    if (perso != null)
                    {
                        FormsAuthentication.SetAuthCookie(perso.Login.ToString(), false);
                        Authentifie = true;
                        Session["Utilisateur"] = utilisateur;
                        ViewData["Authentifie"] = Authentifie;
                        return Redirect("/");
                    }
                }
            }
            return View("Index", utilisateur);
        }
        public ActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inscription(Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    db.Utilisateurs.Add(utilisateur);
                    db.SaveChanges();
                }
                Session["Utilisateur"] = utilisateur;
                FormsAuthentication.SetAuthCookie(utilisateur.Login.ToString(), true);
                return Redirect("/");
            }
            return View(utilisateur);
        }
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}