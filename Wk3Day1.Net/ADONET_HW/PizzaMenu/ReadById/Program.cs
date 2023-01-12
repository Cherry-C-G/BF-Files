using System.Data;
using System.Data.SqlClient;

namespace ReadById
{
    public class Program
    {
        public static readonly string connString = "Persist Security Info=False;Integrated Security=true;  Initial Catalog = ADO_HW; Server=localhost";
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            //3. Read a Pizza given its unique Id
            string query1 = "SELECT Name FROM dbo.Pizza WHERE ID = @id";

            //By DataAdapter
            using (SqlConnection connection2 = new SqlConnection(connString))
            {
                connection2.Open();
                SqlCommand commond2 = new SqlCommand(query1, connection2);
                commond2.Parameters.AddWithValue("@id", id);
                Console.WriteLine("Using DataAdapter:");

                using (SqlDataAdapter adapter = new SqlDataAdapter(commond2))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "dbo.Pizza");
                    DataTable table = dataset.Tables["dbo.Pizza"];
                    //get value
                    object result = table.Rows[0][0];
                    Console.WriteLine(result.ToString());
                }
            }

            //By DataReader
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query1, connection);
                command.Parameters.AddWithValue("@id", id);
                Console.WriteLine("Using DataReader:");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(0));
                }
                object returnedData = command.ExecuteScalar();
                Console.WriteLine(returnedData.ToString());
            }


        }
    }
}