using CourseDaoApplication.Data;
using CourseDaoMVC.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CourseDaoMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentDAO _studentDao;

        public StudentController(IStudentDAO studentDao)
        {
            _studentDao = studentDao;
        }

        public IActionResult Index()
        {
            var students = _studentDao.GetAllStudents();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _studentDao.FindStudentById(id);
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentDao.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = _studentDao.FindStudentById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _studentDao.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = _studentDao.FindStudentById(id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentDao.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
