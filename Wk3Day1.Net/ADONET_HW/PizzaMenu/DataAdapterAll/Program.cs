using System.Data;
using System.Data.SqlClient;

namespace DataAdapterAll
{
    public class Program
    {
        public class Pizza
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
        }


            public static readonly string connString = "Persist Security Info=False;Integrated Security=true;  Initial Catalog = ADO_HW; Server=localhost";
        static void Main(string[] args)
        {

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                // create a new Pizza
                Pizza newPizza = new Pizza
                {
                    Name = "BBQ Chicken Pizza",
                    Price = 25.99f
                };

                // create the insert command and parameters
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Pizza (name, price) VALUES (@name, @price)", connection);
                insertCommand.Parameters.AddWithValue("@name", newPizza.Name);
                insertCommand.Parameters.AddWithValue("@price", newPizza.Price);

                // create the data adapter and set the insert command
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = insertCommand;

                //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //DataSet ds = new DataSet();
                //adapter.Fill(ds, "dbo.Pizza");
                DataTable table = new DataTable();
              

                // insert the new Pizza
                adapter.Update(table);

                // read all Pizzas
                DataTable allPizzas = new DataTable();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Pizza", connection);
                adapter.Fill(allPizzas);
                foreach (DataRow row in allPizzas.Rows)
                {
                    Console.WriteLine($"{row["Id"]}: {row["Name"]} - {row["Price"]}");
                }

                // read a Pizza by its unique Id
                int id = 2;
                DataTable selectedPizza = new DataTable();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Pizza WHERE Id = @id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                adapter.Fill(selectedPizza);
                DataRow pizzaRow = selectedPizza.Rows[0];
                Console.WriteLine($"{pizzaRow["Id"]}: {pizzaRow["Name"]} - {pizzaRow["Price"]}");

                // update a Pizza by its unique Id
                pizzaRow["Name"] = "Veggie Supreme Pizza";
                pizzaRow["Price"] = 22.99;
                adapter.UpdateCommand = new SqlCommand("UPDATE Pizza SET name = @name, price = @price WHERE Id = @id", connection);
                adapter.UpdateCommand.Parameters.AddWithValue("@name", pizzaRow["Name"]);
                adapter.UpdateCommand.Parameters.AddWithValue("@price", pizzaRow["Price"]);
                adapter.UpdateCommand.Parameters.AddWithValue("@id", pizzaRow["Id"]);
                adapter.Update(selectedPizza);

                // delete a Pizza by its unique Id
                pizzaRow.Delete();
                adapter.DeleteCommand = new SqlCommand("DELETE FROM Pizza WHERE Id = @id", connection);
                adapter.DeleteCommand.Parameters.AddWithValue("@id", pizzaRow["Id", DataRowVersion.Original]);
                adapter.Update(selectedPizza);

                // create the stored procedure to retrieve the top 3 expensive Pizzas
                string spSql = "CREATE PROCEDURE TheSignatureMenu AS SELECT TOP 3 * FROM Pizza ORDER BY Price DESC";
                SqlCommand createSpCommand = new SqlCommand(spSql, connection);
                createSpCommand.ExecuteNonQuery();

                // execute the stored procedure
                adapter.SelectCommand = new SqlCommand("TheSignatureMenu", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable top3Pizzas = new DataTable();
                adapter.Fill(top3Pizzas);
                foreach (DataRow row in top3Pizzas.Rows)
                {
                    Console.WriteLine($"{row["Id"]}: {row["Name"]} - {row["Price"]}");
                }
            }

        }
    }
}