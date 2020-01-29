using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class GetUtilisateurController : Controller
    {
        // GET: GetUtilisateur
        public string Index()
        {

            var model = new Model1();
            var users = model.Users;
            string strRturn = "";
            var numQuery =
            from user in users
            select user;

            foreach (var user in users)
            {
                strRturn += "Login = " + user.Login + " / " + "Password = " + user.Password + "<p></p>";
            }

            return strRturn;
        }

        public ActionResult GetUtilisateur()
        {
            var model = new Model1();
            var users = model.Users;
            List<User> usersList = new List<User>();
            string l = "dsqdq";
            var numQuery =
            from user in users
            select user;

            foreach (var user in users)
            {
                usersList.Add(user);
            }
            ViewBag.list = numQuery.ToList();// usersList;
            return View();
        }

        public ActionResult RetourAccueil()
        {
            return View("~/Views/Home/Index.cshtml"); 
        }
    }
}