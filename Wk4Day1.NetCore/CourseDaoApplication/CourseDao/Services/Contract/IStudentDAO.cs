using CourseDaoApplication.Data;

namespace CourseDaoMVC.Services.Contract
{
    public interface IStudentDAO
    {
        Student FindStudentById(int id);
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);



    }
}
