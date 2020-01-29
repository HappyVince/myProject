using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsStratTime.Controllers
{
    public class TeamStratController : Controller
    {
        // GET: CreateStrat
        public ActionResult Index()
        {
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            string path = "C:/Users/Administrateur/source/repos/ProjectTab/CsStratTime/Images/Maps/";
            var listFile = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
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