using EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsStratTime.Controllers
{
    public class MyStratsController : Controller
    {
        // GET: MyStrats
        public ActionResult Index()
        {
          Utilisateur utilisateur = (Utilisateur)Session["Utilisateur"];
            string utilisateurID = Convert.ToString(utilisateur.Id);
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;

            string path = "C:/Users/Administrateur/source/repos/ProjectTab/CsStratTime/Images/UserStrat/";
            var listFile = Directory.GetFiles(path, utilisateurID+"_*", SearchOption.AllDirectories);
            List<string> listFileEnd = new List<string>();
            foreach (var file in listFile)
            {
                listFileEnd.Add(file.Split('/')[9]);
            }
            ViewBag.stratName = listFileEnd;
            return View();
        }

    }
}