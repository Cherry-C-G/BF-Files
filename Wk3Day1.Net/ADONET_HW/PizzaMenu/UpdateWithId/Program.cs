﻿using System.Data;
using System.Data.SqlClient;

namespace UpdateWithId
{

    public class Program
    {
        public static readonly string connString = "Persist Security Info=False;Integrated Security=true;  Initial Catalog = ADO_HW; Server=localhost";
        static void Main(string[] args)
        {
            string query = "UPDATE dbo.Pizza SET Name = @name, Price = @price WHERE Id = @id ";
            //4. Update a Pizza given its unique Id
            //using DataReader
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                Console.WriteLine("Using DataReader:");

                SqlCommand cmd1 = new SqlCommand(query, connection);
                cmd1.Parameters.AddWithValue("@name", "Double Philly Cheese Steak");
                cmd1.Parameters.AddWithValue("@price", 15.50);
                cmd1.Parameters.AddWithValue("@id", 5);
                int affectedRows = cmd1.ExecuteNonQuery();
                Console.WriteLine(affectedRows);
            }

            //using DataAdapter
            string query2 = "SELECT * FROM dbo.Pizza WHERE Id = @id ";
            int id = 15;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                Console.WriteLine("Using DataAdapter:");

                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd2))
                {
                    //create commond builder to help us update
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "dbo.Pizza");
                    DataTable table = ds.Tables["dbo.Pizza"];

                    //create datarow to find id and update
                    //since there is only one row in table, so tablerows[0] is the row. 
                    DataRow row = table.Rows[0];
                    row["name"] = "Five Cheese Pizza";
                    row["price"] = 19.99;
                    adapter.Update(table);

                    table.AcceptChanges();
                    foreach (DataRow row1 in table.Rows)
                    {
                        Console.WriteLine(row1[1] + ", " + row1[2]);
                    }

                }

            }
        }
    }
}