using CourseDaoApplication.Data;
using System.Collections.Generic;

public interface ICourseDAO
{
    void AddCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(int id);
    List<Course> GetAllCourses();
    Course FindCourseById(int id);
    void AssignStudentToCourse(int studentId, int courseId);
    void AssignProfessorToCourse(int professorId, int courseId);
    List<Course> FindStudentCoursesByEmail(string email);
}

