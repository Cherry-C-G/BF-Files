using CourseDaoApplication;
using CourseDaoApplication.Data;
using CourseDaoMVC.Services.Contract;
using Microsoft.Data.SqlClient;

namespace CourseDaoMVC.Services
{
    public class ProfessorDAO : IProfessorDAO
    {
        private readonly string _connectionString;
        private readonly MyDbContext _context;

        public ProfessorDAO(IConfiguration configuration, MyDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;



        }
        public void AddProfessor(Professor professor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("INSERT INTO Professor (FirstName, LastName, Email, Office, Title) VALUES (@FirstName, @LastName, @Email, @Office, @Title)", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", professor.FirstName);
                    command.Parameters.AddWithValue("@LastName", professor.LastName);
                    command.Parameters.AddWithValue("@Email", professor.Email);
                    command.Parameters.AddWithValue("@Office", professor.Office);
                    command.Parameters.AddWithValue("@Title", professor.Title);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateProfessor(Professor professor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("UPDATE Professor SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Office = @Office, Title = @Title WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", professor.FirstName);
                    command.Parameters.AddWithValue("@LastName", professor.LastName);
                    command.Parameters.AddWithValue("@Email", professor.Email);
                    command.Parameters.AddWithValue("@Office", professor.Office);
                    command.Parameters.AddWithValue("@Title", professor.Title);
                    command.Parameters.AddWithValue("@Id", professor.ProfessorId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public Professor FindProfessorById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Professor WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Professor
                            {
                                ProfessorId = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"],
                                Office = (string)reader["Office"],
                                Title = (string)reader["Title"]
                            };
                        }
                    }
                }
            }

            return null;
        }
        public List<Professor> GetAllProfessor()
        {
            var professors = new List<Professor>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Professor", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            professors.Add(new Professor
                            {
                                ProfessorId = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"],
                                Office = (string)reader["Office"],
                                Title = (string)reader["Title"]
                            });
                        }
                    }
                }
            }

            return professors;
        }

        public void DeleteProfessor(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Professor WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}


