using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace E_banking.Controllers
{
    public class BankingController : Controller
    {
        //
        // GET: /Banking/
        [Authorize]
        public ActionResult HomeBank()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddUsers()
        {
            return View();
        }
        public ActionResult Payment(string id )
        {
            ViewBag.id = id;


                        return View();
        }
        public ActionResult beneficiarios()
        {
            return View();

        }
    }
}
