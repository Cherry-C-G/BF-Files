using CourseDaoApplication.Data;
using Microsoft.Data.SqlClient;

namespace CourseDaoApplication
{
    public class CourseDAO : ICourseDAO
    {
        

        //public static readonly string connString = "Persist Security Info=False;Integrated Security=true;  Initial Catalog = DefaultConnection; Server=localhost";

        private readonly string _connectionString;
        private readonly MyDbContext _context;
       
        public CourseDAO(IConfiguration configuration, MyDbContext context )
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
         


        }

        public void AddStudent(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Student (FirstName, LastName, Email) VALUES (@firstName, @lastName, @email)";
                    command.Parameters.AddWithValue("@firstName", student.FirstName);
                    command.Parameters.AddWithValue("@lastName", student.LastName);
                    command.Parameters.AddWithValue("@email", student.Email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddCourse(Course course)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Course (Name, Description, ProfessorId) VALUES (@name, @description, @professorId)";
                    command.Parameters.AddWithValue("@name", course.Name);
                    command.Parameters.AddWithValue("@description", course.Description);
                    command.Parameters.AddWithValue("@professorId", course.ProfessorId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddProfessor(Professor professor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Professor (FirstName, LastName, Email, Office, Title) VALUES (@firstName, @lastName, @email, @office, @title)";
                    command.Parameters.AddWithValue("@firstName", professor.FirstName);
                    command.Parameters.AddWithValue("@lastName", professor.LastName);
                    command.Parameters.AddWithValue("@email", professor.Email);
                    command.Parameters.AddWithValue("@office", professor.Office);
                    command.Parameters.AddWithValue("@title", professor.Title);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AssignStudentToCourse(int studentId, int courseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Student_Course (StudentId, CourseId) VALUES (@studentId, @courseId)";
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@courseId", courseId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AssignProfessorToCourse(int professorId, int courseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Course SET ProfessorId = @professorId WHERE Id = @courseId";
                    command.Parameters.AddWithValue("@professorId", professorId);
                    command.Parameters.AddWithValue("@courseId", courseId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Student SET FirstName = @firstName, LastName = @lastName, Email = @email WHERE Id = @id";
                    command.Parameters.AddWithValue("@firstName", student.FirstName);
                    command.Parameters.AddWithValue("@lastName", student.LastName);
                    command.Parameters.AddWithValue("@email", student.Email);
                    command.Parameters.AddWithValue("@id", student.StudentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCourse(Course course)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Course SET Name = @name, Description = @description, ProfessorId = @professorId WHERE Id = @id";
                    command.Parameters.AddWithValue("@name", course.Name);
                    command.Parameters.AddWithValue("@description", course.Description);
                    command.Parameters.AddWithValue("@professorId", course.ProfessorId);
                    command.Parameters.AddWithValue("@id", course.CourseId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProfessor(Professor professor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Professor SET FirstName = @firstName, LastName = @lastName, Email = @email, Office = @office, Title = @title WHERE Id = @id";
                    command.Parameters.AddWithValue("@firstName", professor.FirstName);
                    command.Parameters.AddWithValue("@lastName", professor.LastName);
                    command.Parameters.AddWithValue("@email", professor.Email);
                    command.Parameters.AddWithValue("@office", professor.Office);
                    command.Parameters.AddWithValue("@title", professor.Title);
                    command.Parameters.AddWithValue("@id", professor.ProfessorId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Course> FindStudentCoursesByEmail(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT c.* FROM Course c INNER JOIN Student_Course sc ON c.Id = sc.CourseId INNER JOIN Student s ON s.Id = sc.StudentId WHERE s.Email = @email";
                    command.Parameters.AddWithValue("@email", email);
                    var courses = new List<Course>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseId = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ProfessorId = reader.GetInt32(reader.GetOrdinal("ProfessorId"))
                            });
                        }
                    }
                    return courses;
                }
            }
        }

        public List<Course> FindProfessorCoursesByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT c.* FROM Course c INNER JOIN Professor p ON c.ProfessorId = p.Id WHERE CONCAT(p.FirstName, ' ', p.LastName) = @name";
                    command.Parameters.AddWithValue("@name", name);
                    var courses = new List<Course>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseId = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ProfessorId = reader.GetInt32(reader.GetOrdinal("ProfessorId"))
                            });
                        }
                    }
                    return courses;
                }
            }
        }

        public Course FindCourseById(int courseId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT c.*, p.* FROM Course c INNER JOIN Professor p ON c.ProfessorId = p.Id WHERE c.Id = @courseId";
                    command.Parameters.AddWithValue("@courseId", courseId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Course
                            {
                                CourseId = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Professor = new Professor
                                {
                                    ProfessorId = reader.GetInt32(reader.GetOrdinal("Id")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Office = reader.GetString(reader.GetOrdinal("Office")),
                                    Title = reader.GetString(reader.GetOrdinal("Title"))
                                }
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void DeleteCourse(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Course WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Course> GetAllCourses()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Course", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var courses = new List<Course>();
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseId = (int)reader["id"],
                                Name = (string)reader["name"],
                                Description = (string)reader["description"],
                                ProfessorId = (int)reader["professorId"]
                            });
                        }
                        return courses;
                    }
                }
            }
        }
    }
}

