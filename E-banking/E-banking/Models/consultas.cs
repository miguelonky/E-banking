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

        public virtual bool Autenticar(string usuario, string contraseña)
        {
             bool autenticado = false;
             /* string query = string.Format("SELECT * FROM [User] WHERE usuario = '{0}' AND contraseña = '{1}'", usuario, contraseña);

             SqlCommand cmd = new SqlCommand(query, conn);
             conn.Open();
             SqlDataReader sdr = cmd.ExecuteReader();
             authenticato = sdr.HasRows;  */

            var da = new SqlDataAccess("UseConfig");
            da.SetProc("Autenticar");
            da.AddParameter("@usuario", usuario);
            da.AddParameter("@contraseña", contraseña);
            da.ExecuteDataSet();

             return autenticado;


        }
    }
}