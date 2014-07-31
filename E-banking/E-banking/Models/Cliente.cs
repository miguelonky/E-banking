using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace E_banking.Models
{
    public class Cliente
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string cedula { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string birthdate { get; set; }
        public string role { get; set; }
        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;

        public Cliente(string fname, string lname, string cedula, string email, string phone, string birthdate, string role)
        {
            this.fname = fname;
            this.lname = lname;
            this.cedula = cedula;
            this.email = email;
            this.phone = phone;
            this.birthdate = birthdate;
            this.role = role;
        }

        public void AddClient(Cliente cliente)
        {
            var db = new SqlDataAccess("UseConfig");

            db.SetProc("sp_add_client");
            db.AddParameter("@fname", cliente.fname);
            db.AddParameter("@lname", cliente.lname);
            db.AddParameter("@cedula", cliente.cedula);
            db.AddParameter("@email", cliente.email);
            db.AddParameter("@phone", cliente.phone);
            db.AddParameter("@birth_date", cliente.birthdate);
            db.AddParameter("@role", cliente.role);
            db.ExecuteDataSet();
        }
    }
}