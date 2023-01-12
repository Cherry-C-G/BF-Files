using CourseDaoApplication.Data;

namespace CourseDaoApplication
{
    public interface ICourseDAO
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourse(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        object FindCourseById(int id);
        object FindStudentCourseByStudentEmail(string studentEmail);
        object FindProfessorCourseByName(string professorName);

    }
}
