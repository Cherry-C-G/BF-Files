using CourseDaoApplication;
using CourseDaoApplication.Data;
using Microsoft.Data.SqlClient;

namespace CourseDaoMVC.Services
{
    public class Student_CourseDAO
    {
        private readonly string _connectionString;
        private readonly MyDbContext _context;

        public Student_CourseDAO(IConfiguration configuration, MyDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;

        }
        public void AddStudent_Course(Student_Course student_Course)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var addStudent_CourseCommand = @"INSERT INTO Student_Course (StudentId, CourseId) VALUES (@studentId, @courseId)";

                var cmd = new SqlCommand(addStudent_CourseCommand, conn);
                cmd.Parameters.AddWithValue("@studentId", student_Course.StudentId);
                cmd.Parameters.AddWithValue("@courseId", student_Course.CourseId);

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudent_Course(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var deleteStudent_CourseCommand = @"DELETE FROM Student_Course WHERE Id = @id";

                var cmd = new SqlCommand(deleteStudent_CourseCommand, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Student_Course> GetAllStudent_Courses()
        {
            var student_Courses = new List<Student_Course>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var getAllStudent_CoursesCommand = @"SELECT * FROM Student_Course";

                var cmd = new SqlCommand(getAllStudent_CoursesCommand, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student_Courses.Add(new Student_Course
                    {
                        Id = (int)reader["Id"],
                        StudentId = (int)reader["StudentId"],
                        CourseId = (int)reader["CourseId"]
                    });
                }
            }

            return student_Courses;
        }
    }
}

