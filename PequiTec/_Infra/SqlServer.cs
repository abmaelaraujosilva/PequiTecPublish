using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PequiTec._Infra
{
    public class SqlServer : IDB
    {
        SqlConnection _con;
        public void Dispose()
        {
            _con.Close();
            _con.Dispose();
        }

        public IDbConnection Getconnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["PequiTec"].ConnectionString);
        }
    }
}