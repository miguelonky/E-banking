using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_banking.Controllers
{
    public class BankingController : Controller
    {
        //
        // GET: /Banking/

        public ActionResult HomeBank()
        {
            return View();
        }

        public ActionResult AddUsers()
        {
            return View();
        }
    }
}
