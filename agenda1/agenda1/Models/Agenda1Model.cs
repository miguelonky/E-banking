using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agenda1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
   

    public class Agenda1Model
    {
        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;

        public virtual void GetReportFilterTable(string name, string lastName, string phoneNumber)
        {
            var da = new SqlDataAccess("UseConfig");

            da.SetProc("SaveContact");
            da.AddParameter("@name", name);
            da.AddParameter("@lastName", lastName);
            da.AddParameter("@phoneNumber", phoneNumber);
            da.ExecuteDataSet();


         
        }
    }
}