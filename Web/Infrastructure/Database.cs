using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data.Common;
    using System.Data.SqlClient;

    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            try
            {
                _connection = new SqlConnection(conn);

                _connection.Open();
            }
            catch (Exception e)
            {
                //For demo purpose i put the try ctach and writting into the console.
                //in real scenarios we can log exception to log file or write into databse.
                Console.WriteLine(e.Message);
            }

        }


        public DbDataReader ExecuteReader(string query)
        {


            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

    }
}