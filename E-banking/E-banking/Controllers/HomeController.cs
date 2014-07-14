using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_banking.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /TestView/

        public ActionResult Index()
        {
            return View();
        }

    }
}
