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
                using (var db = new ProjectManagerDBEntities2())
                {
                    var task = new Parent_Task { Parent_Task1 = "Review Tasks" };
                    db.Parent_Task.Add(task);
                    db.SaveChanges();
                    
                    var query = from b in db.Parent_Task
                                orderby b.Parent_ID
                                select b;

                    Console.WriteLine("All blogs in the database:");
                    foreach (var item in query)
                    {
                        Console.WriteLine(item.Parent_ID);
                        Console.WriteLine(item.Parent_Task1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}