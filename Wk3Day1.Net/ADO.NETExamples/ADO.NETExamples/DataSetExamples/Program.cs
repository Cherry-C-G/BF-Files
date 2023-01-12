using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataAdapterUpdateExamples
{
    internal class Program
    {
        public static readonly string connString =
           //"Persist Security Info=False;User ID=SA;Password=Beaconfire1234;Initial Catalog=Student;Server=localhost";
           "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Student; Server=localhost";
        static void Main(string[] args)
        {
            #region DataTableExample
            string query = "SELECT * FROM StudentClass";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                // database data => in-memory data 
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    //Console.WriteLine(row["ClassId"] + ", " + row["ClassName"]);
                }

                // If I want to make some changes to the table
                //Update a value
                dataTable.Rows[1]["ClassName"] = "Dec Batch";
                //Delete a value
                foreach (DataRow row in dataTable.Rows)
                {
                    if (Convert.ToInt32(row[0]) == 1)
                    {
                        row.Delete();  // This doesn't remove the row in dataTable, but sets its RowState to Deleted
                        Console.WriteLine("Row in " + row.RowState + " State");
                    }
                }
                //dataTable.AcceptChanges();
                //Use SqlCommandBuilder to help us create the SqlCommand and apply on the adapter
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);

                //Reflect changes to our  Database
                adapter.Update(dataTable);
                Console.WriteLine("Changes update to the database via SqlDataAdapter");

                //Commit the changes to dataset
                dataTable.AcceptChanges();
                Console.WriteLine("Changes reflect to the  datatable");
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["ClassId"] + ", " + row["ClassName"]);
                }
            }
            #endregion
        }
    }
}
