using CourseDaoMVC.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CourseDaoMVC.Controllers
{
    public class Student_CourseController : Controller
    {
        private readonly IStudent_CourseDAO _student_CourseDAO;
        public Student_CourseController(IStudent_CourseDAO student_CourseDAO)
        {
            _student_CourseDAO = student_CourseDAO;
        }

        public IActionResult Index()
        {
            return View(_student_CourseDAO.GetAllStudent_Courses());
        }

        public IActionResult Delete(int id)
        {
            _student_CourseDAO.DeleteStudent_Course(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student_CourseController student_Course)
        {
            //_student_CourseDAO.AddStudent_Course(student_Course);
            return RedirectToAction("Index");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
