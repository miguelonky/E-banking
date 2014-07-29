using E_banking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_banking.Controllers
{
    public class HomeController : Controller
    {
        //system.data

        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;


        //objeto de la clase modelo de consultas
        consultas Cs = new consultas();


        //
        // GET: /TestView/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string contraseña)
        {
            //no eh echo mas porque no eh creado la base de datos aun 
            string user = usuario;
            string pass = contraseña;
            bool vali = Cs.Autenticar(user, pass);
            if (vali)
            {
                //FormsAuthentication.SetAuthCookie(user, true);
                return RedirectToAction("Home", "HomeBank");
            }
            {
              ViewBag.error = "Usuario o contraseña incorrecta";
            }
           
            return View();
        }
    }
}
