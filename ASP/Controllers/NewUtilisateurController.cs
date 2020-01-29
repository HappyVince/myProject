using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class NewUtilisateurController : Controller
    {
        // GET: NewUtilisateur
        public string Index(string login, string password)
        {
            var model = new Model1();
            var users = model.Users;
            users.Add(new User(login, password));
            model.SaveChanges();
            return "Utilisateur ajoutée";
        }
    }
}