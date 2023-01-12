using System.Data;
using System.Data.SqlClient;

namespace DataReaderAll
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
           // create a new Pizza object
           Pizza pizza = new Pizza()
           {
               Name = "pepperoni pizza",
               Price = 42.42f
           };

            //Pizza pizza1 = new Pizza { Name = "pepperoni pizza", Price = 42.42f };
            //Pizza pizza2 = new Pizza { Name = "veggie pizza", Price = 12.34f };
            //Pizza pizza3 = new Pizza { Name = "margherita pizza", Price = 1.23f };
            //Pizza pizza4 = new Pizza { Name = "square pizza", Price = 3.14f };
            //Pizza pizza5 = new Pizza { Name = "triple cheese pizza", Price = 33.3f };
            //Pizza pizza6 = new Pizza { Name = "leaning tower of pizza", Price = 10.0f };

            //List<Pizza> pizzas = new List<Pizza> { pizza1, pizza2, pizza3, pizza4, pizza5, pizza6 };


            // insert the Pizza object into the database (Create)
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Pizza (name, price) VALUES (@name, @price)", connection))
                {
                    command.Parameters.AddWithValue("@name", pizza.Name);
                    command.Parameters.AddWithValue("@price", pizza.Price);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            // read all Pizzas from the database (Read)
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Pizza", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            // read a Pizza by its unique Id (Read)
            int id = 1;
            Pizza pizzaById = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Pizza WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pizzaById = new Pizza()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetFloat(2)
                            };
                        }
                    }
                }
            }

            // update a Pizza by its unique Id (Update)
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Pizza SET name = @name, price = @price WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@name", "veggie pizza");
                    command.Parameters.AddWithValue("@price", 12.34);
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            // delete a Pizza by its unique Id (Delete)
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Pizza WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            // create a stored procedure to get the top 3 expensive Pizzas (Create)
//            string createProcedureSql = @"CREATE PROCEDURE TheSignatureMenu AS
//SELECT TOP 3 * FROM Pizza ORDER BY Price DESC";
//            using (SqlConnection connection = new SqlConnection(connString))
//            {
//                connection.Open();
//                using (SqlCommand command = new SqlCommand(createProcedureSql, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//            }
            // execute the stored procedure (Read)
            DataTable top3Table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("TheSignatureMenu", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        top3Table.Load(reader);
                    }
                }
            }
            // drop the stored procedure (Delete)
            string dropProcedureSql = "DROP PROCEDURE TheSignatureMenu";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(dropProcedureSql, connection))
                {
                    command.ExecuteNonQuery();
                }

            }
        }

    }
}