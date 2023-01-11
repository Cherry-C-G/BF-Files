using CourseDaoApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace CourseDaoApplication
{
    public class HomeController : ControllerBase
    {
        private readonly CourseDAO _courseDAO;

        public HomeController(CourseDAO courseDAO)
        {
            _courseDAO = courseDAO;
        }
        [Route("privacy")]

        //public IActionResult Index()
        //{
        //    var courses = _courseDAO.FindStudentCoursesByEmail("jane.doe@example.com");
        //    return View(courses);
        //}

        //public IActionResult AddStudent()
        //{
        //    _courseDAO.AddStudent(new Student { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" });
        //    _courseDAO.AssignStudentToCourse(1, 2); // Assigns student with ID 1 to course with ID 2
        //    _courseDAO.UpdateProfessor(new Professor { Id = 3, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Office = "123", Title = "Professor" });
        //    var course = _courseDAO.FindCourseById(1);

        //    return View();
        //}

        // [HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}


        // [HttpPost]
        public  IActionResult AddStudent(Student student)
        {
             _courseDAO.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateStudent(Student student)
        {
            _courseDAO.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult AddCourse(Course course)
        {
            _courseDAO.AddCourse(course);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCourse(Course course)
        {
            _courseDAO.UpdateCourse(course);
            return RedirectToAction("Index");
        }

        public IActionResult AddProfessor(Professor professor)
        {
            _courseDAO.AddProfessor(professor);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProfessor(Professor professor)
        {
            _courseDAO.UpdateProfessor(professor);
            return RedirectToAction("Index");
        }

        public IActionResult AssignStudentToCourse(int studentId, int courseId)
        {
            _courseDAO.AssignStudentToCourse(studentId, courseId);
            return RedirectToAction("Index");
        }

        public IActionResult AssignProfessorToCourse(int professorId, int courseId)
        {
            _courseDAO.AssignProfessorToCourse(professorId, courseId);
            return RedirectToAction("Index");
        }

    }
}
