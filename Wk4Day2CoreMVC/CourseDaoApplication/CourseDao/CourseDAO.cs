using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CourseDaoApplication.Data;


public class CourseDAO : ICourseDAO
{
    private readonly IConfiguration _config;

    public CourseDAO(IConfiguration config)
    {
        _config = config;
    }

    public void AddCourse(Course course)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Course (Name, Description, ProfessorId) VALUES (@name, @description, @professorId)", conn);
            cmd.Parameters.AddWithValue("@name", course.Name);
            cmd.Parameters.AddWithValue("@description", course.Description);
            cmd.Parameters.AddWithValue("@professorId", course.ProfessorId);
            cmd.ExecuteNonQuery();
        }
    }

    public void AssignProfessorToCourse(int professorId, int courseId)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Course SET ProfessorId = @professorId WHERE Id = @courseId", conn);
            cmd.Parameters.AddWithValue("@professorId", professorId);
            cmd.Parameters.AddWithValue("@courseId", courseId);
            cmd.ExecuteNonQuery();
        }
    }

    public void AssignStudentToCourse(int studentId, int courseId)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student_Course (StudentId, CourseId) VALUES (@studentId, @courseId)", conn);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@courseId", courseId);
            cmd.ExecuteNonQuery();
        }
    }


    public void DeleteCourse(int id)
    {
        using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Course WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public Course FindCourseById(int id)
    {
        Course course = null;
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    course = new Course
                    {
                        CourseId = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        ProfessorId = (int)reader["ProfessorId"]
                    };
                }
            }
        }
        return course;
    }

    public List<Course> GetAllCourses()
    {
        List<Course> courses = new List<Course>();
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course", conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course course = new Course
                    {
                        CourseId = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        ProfessorId = (int)reader["ProfessorId"]
                    };
                    courses.Add(course);
                }
            }
        }
        return courses;
    }


    public void UpdateCourse(Course course)
    {
        using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Course SET Name = @name, Description = @description, ProfessorId = @professorId WHERE Id = @id";
                command.Parameters.AddWithValue("@name", course.Name);
                command.Parameters.AddWithValue("@description", course.Description);
                command.Parameters.AddWithValue("@professorId", course.ProfessorId);
                command.Parameters.AddWithValue("@id", course.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}

    