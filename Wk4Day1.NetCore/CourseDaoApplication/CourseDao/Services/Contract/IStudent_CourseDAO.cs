using CourseDaoApplication.Data;

namespace CourseDaoMVC.Services.Contract
{
    public interface IStudent_CourseDAO
    {
        public void AddStudent_Course(Student_Course student_Course);
        public void DeleteStudent_Course(int id);
        public List<Student_Course> GetAllStudent_Courses();
    }
}
