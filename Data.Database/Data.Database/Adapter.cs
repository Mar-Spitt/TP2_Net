using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        const string consKeyDefaultCnnString = "ConnStringExpress";

        protected SqlConnection sqlConn
        {
            get; set;
        }

        protected void OpenConnection()
        {   
            string  connstring = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = connstring;
            
            sqlConn.Open();

        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
