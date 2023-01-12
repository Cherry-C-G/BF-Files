using FormExample.Models;
using System.Data.SqlClient;

namespace FormExample.DAL
{

    public class CategoryDao
    {
        private readonly IConfiguration _configuration; //dependency
        private readonly string _selectAllQuery = "SELECT * FROM Category"; // normal field
        private readonly string _insertQuery = "INSERT INTO Category VALUES (@Name)";
        private readonly string _updateQuery = "UPDATE Category SET Name = @Name WHERE Id = @Id";
        private readonly string _deleteQuery = "DELETE FROM Category WHERE Id = @Id";
        //Inject the dependecy using Constructor Injection
        public CategoryDao(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Get All Category in the database and put them in a collection of Category Models
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            using (var conn = new SqlConnection(_configuration.GetConnectionString("MyConn")))
            {
                conn.Open();
                var cmd = new SqlCommand(_selectAllQuery, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        categories.Add(
                            new Category()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                            }
                            );
                    }
                }
            }

            return categories;
        }

        public int AddCategory(Category category)
        {
            int rowAffected;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("MyConn")))
            {
                conn.Open();
                var cmd = new SqlCommand(_insertQuery, conn);
                cmd.Parameters.AddWithValue("@Name", category.Name);
                rowAffected= cmd.ExecuteNonQuery();
            }
            return rowAffected;
        }

        public int UpdateCategory (Category updatedCategory)
        {
            int rowAffected;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("MyConn")))
            {
                conn.Open();
                var cmd = new SqlCommand(_updateQuery, conn);
                cmd.Parameters.AddWithValue("@Name", updatedCategory.Name);
                cmd.Parameters.AddWithValue("@Id", updatedCategory.Id);
                rowAffected = cmd.ExecuteNonQuery();
            }
            return rowAffected;
        }

        public int DeleteCategory (Category category) 
        { 
            int rowAffected;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("MyConn")))
            {
                conn.Open();
                var cmd = new SqlCommand(_deleteQuery, conn);
                cmd.Parameters.AddWithValue("@Id", category.Id);
                rowAffected = cmd.ExecuteNonQuery();
            }
            return rowAffected;
        }
    }
}
