using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using agenda1.Models;


namespace agenda1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using  agenda1;
    
    
    public class HomeController : Controller
    {
        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;
        Agenda1Model Sp = new Agenda1Model();
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string lastname, string phone)
        {
            
            string nombre = name;
            string apellido = lastname;
            string telefono = phone;



            Sp.GetReportFilterTable(nombre, apellido, telefono);
            return View();
        }

      

    }
}
