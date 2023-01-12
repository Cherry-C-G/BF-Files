using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataAdapterExamples
{
    internal class Program
    {
        public static readonly string connString =
           //"Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost";
           "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
        static void Main(string[] args)
        { 
            try
            {
                string query = "SELECT * FROM StudentClass";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //Establish connection
                    conn.Open();
                    //Create an instance of the SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    
                    //Use Data Table
                    DataTable dataTable = new DataTable();
                    //Fill() the data table
                    adapter.Fill(dataTable);
                    Console.WriteLine("Data Table Result:");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row["ClassId"] + ", " + row["ClassName"]);
                    }

                    Console.WriteLine("--------------------------");

                    //Use DataSet
                    DataSet dataSet = new DataSet();
                    //Add the DataTable - "ClassInfo" to a specific DataSet
                    adapter.Fill(dataSet, "ClassInfo");
                    Console.WriteLine("Data Set Result: ");
                    foreach (DataRow row in dataSet.Tables["ClassInfo"].Rows)
                    {
                        Console.WriteLine(row[0] + ", " + row[1]);
                    }
                    
                }

                #region Stored Procedure Example
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("DataTable Result(Stored Procedure) : ");
                    SqlDataAdapter adapter = new SqlDataAdapter("GetAllClassName", conn);
                    //Specify the Command type as Stored Procedure
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row["ClassName"]);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong with SqlDataAdapter: " + ex.Message);
                throw ex;
            }
        }
    }
}
