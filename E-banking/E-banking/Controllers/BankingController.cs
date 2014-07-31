using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using E_banking.Models;
using System.Security.Principal;
namespace E_banking.Controllers
{
        
    public class BankingController : Controller
    {
       consultas Cs = new consultas();

        string value;
       

        // GET: /Banking/
        [Authorize]
        public ActionResult HomeBank()
        {
            
            Models.consultas objConsultas = new consultas();

            return View(objConsultas.ViewAccounts());
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

        //public ActionResult viewAccounts()
        //{
        //  Models.consultas objConsultas=new consultas();

        //  return View(objConsultas.ViewAccounts());

        //}
    }

    
}
