using System;
using System.Data.SqlClient;

namespace SqlConnectionExamples
{
   
    internal class Program
    {
        public static readonly string connString =
            //"Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost;";
            "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
        static void Main(string[] args)
        {
            #region Establish Connection to SQL Server (Try Catch Finally) 
            //Establish Connection
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();
                Console.WriteLine(conn.Database);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong with the databse connection: " + ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            #endregion

            #region Establish Connection to SQL Server (Using)
            //using (SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
            //    Console.WriteLine(conn.Database);
            //    // we don't need to explicitly close the connection
            //    // however if you want to catch exceptions, you can surround your using block with try catch blocks
            //}
            #endregion
        }


    }
}
