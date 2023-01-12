using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReaderPizzaMenu
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
    string connectionString = "Server=localhost;Database=ADO_HW;Trusted_Connection=True;";

    using (SqlConnection connection = new SqlConnection(connectionString))
   {
    connection.Open();
        // create the table
string createTable = @"CREATE TABLE Pizza (
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(42),
Price FLOAT
)";
using (SqlCommand command = new SqlCommand(createTable, connection))
{
command.ExecuteNonQuery();
}




public class DataReaderPizzaMenu
    {

    }
}
