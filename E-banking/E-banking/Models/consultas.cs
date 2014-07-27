using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace E_banking.Models
{
    public class consultas
    {
        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;

        public virtual void Autenticar(string usuario, string contraseña)
        {
            var da = new SqlDataAccess("UseConfig");

            da.SetProc("Autenticar");
            da.AddParameter("@usuario", usuario);
            da.AddParameter("@contraseña", contraseña);
            da.ExecuteDataSet();



        }
    }
}