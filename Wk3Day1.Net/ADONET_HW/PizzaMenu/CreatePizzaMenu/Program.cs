//There is a pizza shop in East Windsor that requires some CRUD operations to be implemented using ADO.NET(try to use both DataReader and DataAdapter to implement the functions below);

//1.Create a Pizza on the menu
//2.Read all Pizzas from the shop
//3.Read a Pizza given its unique Id
//4.Update a Pizza given its unique Id
//5.Delete a Pizza by its unique Id
//6.Create an UD-Stored Procedure called “The Signiture Menu” to get TOP3 expensive Pizzas and execute the SP using your.NET application



using Bogus.DataSets;
using System.Data;
using System.Data.SqlClient;

namespace CreatePizzaMenu
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class Program
    {
        public static readonly string connString = "Persist Security Info=False;Integrated Security=true;  Initial Catalog = ADO_HW; Server=localhost";
        static void Main(string[] args)
        {
            string query = "SELECT * FROM dbo.Pizza";

            //using SqlDataAdapter to insert row
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();


                //fetch data from database to adpter then fill into local dataTable

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                //inserting rows to datatable
                DataRow newRow = dataTable.NewRow();
                newRow[1] = "Philly Cheese Steak Pizza";
                newRow[2] = 15.88;
                dataTable.Rows.Add(newRow);

                dataTable.AcceptChanges();


                //using CommandBuilder to create SqlCommand and apply on the adapter
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                //relect chbages to database
                adapter.Update(dataTable);
                Console.WriteLine("Changes update to the database via SqlDataAdapter");

                //Commit changes to dataset
                dataTable.AcceptChanges();
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    Console.WriteLine(row[1] + ", " + row[2]);
                //}
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    Pizza pizza = new Pizza()
                //    {
                //        Id = int.Parse(row["Id"].ToString()),
                //        Name = row["Name"].ToString(),
                //        Price = float.Parse(row[2].ToString())
                //    };
                //}
            }

            //using DataReader to insert row
            using (SqlConnection conn2 = new SqlConnection(connString))
            {
                conn2.Open();
                string insert = "INSERT INTO dbo.Pizza VALUES(@value1,@value2)";
                using (SqlCommand command = new SqlCommand(insert, conn2))
                {
                    command.Parameters.AddWithValue("@value1", "Double Cheese Pizza");
                    command.Parameters.AddWithValue("@value2", 9.99);
                    int rowAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowAffected + " row(s) affected.");
                }
            }


        }
    }
}