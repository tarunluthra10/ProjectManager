using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectManager.Web
{
    public class DatabaseConnectionSetup
    {
        string connetionString;

        public DatabaseConnectionSetup()
        {
            connetionString = @"Data Source = DESKTOP-SVAHEAE\SQLEXPRESS; Initial Catalog = ProjectManagerDB; Persist Security Info = True;User ID=sa;Password=pass@word1";
        }
        public void Connection()
        {
           try
            {
                SqlConnection cnn;
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT count(1) FROM Parent_Task", cnn);
                var count = command.ExecuteScalar();
                cnn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    // Create the connectionString
            //    // Trusted_Connection is used to denote the connection uses Windows Authentication
            //    conn.ConnectionString = connetionString;
            //    conn.Open();
            //    // Create the command
            //    SqlCommand command = new SqlCommand("SELECT * FROM Parent_Task", conn);

            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {


            //    }
            //}
        }
    }
}