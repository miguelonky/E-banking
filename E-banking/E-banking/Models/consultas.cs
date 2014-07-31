using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;

namespace E_banking.Models
{
    public class consultas
    {
        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;
        public int id;
        public List<Account> accounts;

        public consultas()
        {
            accounts = new List<Account>();
        }
        ClientInfo clInfo = new ClientInfo();
        public virtual bool Autenticar(string usuario, string contraseña)
        {

            var da = new SqlDataAccess("UseConfig");
            da.SetProc("LoginValidation");
            da.AddParameter("@User", usuario);
            da.AddParameter("@password", contraseña);
            _reportTable = da.ExecuteDataSet().Tables[0];

            Boolean valor = bool.Parse(_reportTable.Rows[0]["validar"].ToString());
            
            id = int.Parse(_reportTable.Rows[0]["ClientID"].ToString());
            

            return valor;


        }

        public virtual List<Account> ViewAccounts()
        {
           string cliente = HttpContext.Current.User.Identity.Name;;
            var da = new SqlDataAccess("UseConfig");
            da.SetProc("searchAccounts");
            da.AddParameter("@UserName", cliente);
            _reportTable = da.ExecuteDataSet().Tables[0];

            

            int row = _reportTable.Rows.Count;

            for (int x = 0; x < _reportTable.Rows.Count; x++)
            {
                Account accountList = new Account();

                accountList._Id = int.Parse(_reportTable.Rows[x]["id"].ToString());
                accountList._Alias = _reportTable.Rows[x]["type"].ToString();
                accountList._AccountNumber = _reportTable.Rows[x]["account_number"].ToString();
                accountList._Type = _reportTable.Rows[x]["type"].ToString();
                accountList._Balance = _reportTable.Rows[x]["balance"].ToString();
                accountList._BalanceAvailable = _reportTable.Rows[x]["balance_available"].ToString();

                accounts.Add(accountList);


            }


            return accounts;
        }


    }

}