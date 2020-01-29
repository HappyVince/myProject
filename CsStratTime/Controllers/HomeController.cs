using EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Test()
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

        [HttpPost]
        public ActionResult Test(string imageData)
        {
            string path = "C:/Users/Administrateur/source/repos/ProjectTab/CsStratTime/Images/UserStrat/";
            string fileNameWitPath = path + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png";
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
            return View("Test");
        }


        [HttpPost]
        public ActionResult Try(HttpPostedFileBase file, string imgName)
        {
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            string pathh = "C:/Users/Administrateur/source/repos/ProjectTab/CsStratTime/Images/Maps/";
            var listFile = Directory.GetFiles(pathh, "*", SearchOption.AllDirectories);
            List<string> listFileEnd = new List<string>();
            foreach (var filee in listFile)
            {
                listFileEnd.Add(filee.Split('/')[9]);
            }
            ViewBag.stratName = listFileEnd;



            if (file != null)
            {
                Utilisateur utilisateur = (Utilisateur)Session["Utilisateur"];
                imgName = Convert.ToString(utilisateur.Id) + "_" + imgName + ".png";
                string path = Path.Combine(Server.MapPath("~/Images/UserStrat/"), imgName);
                file.SaveAs(path);
                ViewBag.path = path;

            }
            return View("Test");
        }



    }
}