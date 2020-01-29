using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class SommeController : Controller
    {
        // GET: Somme
        public int Index(int a, int b)
        {
            return a+b;
        }
    }
}