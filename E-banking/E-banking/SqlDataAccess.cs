using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_banking
{

    #region
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Security;
    using System.Runtime.InteropServices;
    using System.Data.Sql;
    using System.Configuration;
    #endregion

    public class SqlDataAccess : IDisposable
    {
        public static String Connection { get; set; }

        private readonly SqlConnection _sqlConnection;

        private readonly SqlCommand _sqlCommand;

        #region Constructors

        public SqlDataAccess(string dBServer, string dBName, SecureString dBUser, SecureString dBPass)
        {
            _sqlConnection = new SqlConnection("data source=" + dBServer + ";Initial Catalog=" + dBName +
                ";uid=" + ConvertToUnsecureString(dBUser) +
                ";pwd=" + ConvertToUnsecureString(dBPass));
            _sqlCommand = new SqlCommand { Connection = this._sqlConnection };
        }

        public SqlDataAccess(string key)
        {
            key = Connection ?? key;

            _sqlConnection = new SqlConnection(key == "UseConfig" ? ConfigurationManager.AppSettings["connectionstring"] : key);

            _sqlCommand = new SqlCommand { Connection = _sqlConnection };
        }

        #endregion

        #region Helper Functions

        private static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("The argument securePassword must be a not null value.");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public void SetProc(string mProcName, int commandTimeOut = 1800)
        {
            _sqlCommand.CommandTimeout = commandTimeOut;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = mProcName;
        }

        public void SetQuery(string sqlQuery, CommandType commandType, int commandTimeOut = 1800)
        {
            _sqlCommand.CommandTimeout = commandTimeOut;
            _sqlCommand.CommandType = commandType;
            _sqlCommand.CommandText = sqlQuery;
        }

        public void AddParameter(string mParameterName, string mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, Guid mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, DateTime mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, int mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, double mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, Decimal mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, float mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, bool mParameterValue)
        {
            _sqlCommand.Parameters.Add(mParameterName, SqlDbType.Bit).Value = mParameterValue;
        }

        public void AddParameter(string mParameterName, System.DBNull mParameterValue)
        {
            _sqlCommand.Parameters.AddWithValue(mParameterName, mParameterValue);
        }

        public void AddParameter(string mParameterName, IEnumerable mParameterValue)
        {
            var str = new StringBuilder();
            foreach (var t in mParameterValue)
            {
                str.AppendFormat("{0},", t);
            }

            var value = str.ToString(0, str.Length - 1);
            _sqlCommand.Parameters.AddWithValue(mParameterName, value);
        }

        public object ExecuteScalarAsObject()
        {
            object returnedObject;
            try
            {
                _sqlConnection.Open();
                returnedObject = _sqlCommand.ExecuteScalar();
            }
            finally
            {
                _sqlConnection.Close();

            }
            return returnedObject;
        }

        public string ExecuteScalar()
        {
            string str;
            try
            {
                _sqlConnection.Open();
                str = Convert.ToString(_sqlCommand.ExecuteScalar());
            }
            finally
            {
                _sqlConnection.Close();

            }
            return str;
        }

        public SqlDataReader ExecuteReader()
        {
            SqlDataReader rd;
            try
            {
                _sqlConnection.Open();
                rd = _sqlCommand.ExecuteReader();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return rd;
        }

        public int ExecuteNonQuery()
        {
            int rowsAffected = 0;
            try
            {
                _sqlConnection.Open();
                rowsAffected = _sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return rowsAffected;
        }

        public DataSet ExecuteNonScalar()
        {

            var dataSet = new DataSet();
            try
            {
                var sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                sqlDataAdapter.Fill(dataSet);

            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        public DataSet ExecuteDataSet()
        {

            var dataSet = new DataSet();
            try
            {
                var sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                sqlDataAdapter.Fill(dataSet);

            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// Execute a sql query and return only the first table. If multiple tables are returned only the first one will be obtained.
        /// </summary>
        /// <returns>Represent a collection of data obtained after execute a sql query.</returns>
        public DataTable ExecuteNonScalarFirstTable()
        {
            var dataTable = new DataTable();
            try
            {
                var sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            finally
            {
                _sqlConnection.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// Clears stored procedure and parameters from the SqlDataAccess object
        /// </summary>
        public void Clear()
        {
            _sqlCommand.CommandText = "";
            _sqlCommand.Parameters.Clear();
        }

        #endregion

        #region Implemented Interface

        public void Dispose()
        {
            _sqlConnection.Dispose();
            _sqlCommand.Dispose();
        }

        #endregion
    }
}