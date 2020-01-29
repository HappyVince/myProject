using EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsStratTime.Controllers
{
    public class CreateStratController : Controller
    {
        // GET: CreateStrat
        public ActionResult Index()
        {

/*            using (var db = new Model1())
            {
                Strat strat = new Strat(1, "../Images/UserStrat/","3-2b");
                Utilisateur utilisateur = (Utilisateur)Session["Utilisateur"];
                strat.IdUtilisateur = utilisateur.Id;
                db.Strats.Add(strat);
                db.SaveChanges();
            }*/


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
        public ActionResult Index(HttpPostedFileBase file,string imgName)
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
            imgName = Convert.ToString(utilisateur.Id) + "_" + imgName+".png";
            string path = Path.Combine(Server.MapPath("~/Images/UserStrat/"), imgName);
            file.SaveAs(path);
            ViewBag.path = path;

            }
            return View();
        }


        [HttpPost]
        public ActionResult SaveStrat(string imageData, string imageName)
        {
            Utilisateur utilisateur = (Utilisateur)Session["Utilisateur"];
            string path = "C:/Users/Administrateur/source/repos/ProjectTab/CsStratTime/Images/UserStrat/";
            string imgName = Convert.ToString(utilisateur.Id) + "_" + imageName;
            string fileNameWitPath = path + imgName + ".png";
            using (var db = new Model1())
            {
                db.Strats.Add(new Strat(utilisateur.Id, fileNameWitPath, imgName));
                db.SaveChanges();
            }
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
    }
}