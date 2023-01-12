

using Microsoft.AspNetCore.Mvc;
using CourseDaoApplication.Data;

namespace YourApplication.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseDAO _courseDao;
        public CourseController(ICourseDAO courseDao)
        {
            _courseDao = courseDao;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            _courseDao.AddCourse(course);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Course course = _courseDao.FindCourseById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Update(Course course)
        {
            _courseDao.UpdateCourse(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: Course
        public IActionResult Index()
        {
            return View(_courseDao.GetAllCourses());
        }

        // GET: Course/Details/5
        public IActionResult Details(int id)
        {
            var course = _courseDao.FindCourseById(id);
            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDao.AddCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int id)
        {
            var course = _courseDao.FindCourseById(id);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDao.UpdateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public IActionResult Delete(int id)
        {
            var course = _courseDao.FindCourseById(id);
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseDao.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        //GET: Course/AssignStudentToCourse
        public IActionResult AssignStudentToCourse()
        {
            return View();
        }

        // POST: Course/AssignStudentToCourse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignStudentToCourse(int studentId, int courseId)
        {
            _courseDao.AssignStudentToCourse(studentId, courseId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Course/AssignProfessorToCourse
        public IActionResult AssignProfessorToCourse()
        {
            return View();
        }

        // POST: Course/AssignProfessorToCourse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignProfessorToCourse(int professorId, int courseId)
        {
            _courseDao.AssignProfessorToCourse(professorId, courseId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FindStudentCoursesByEmail(string email)
        {
            List<Course> courses = _courseDao.FindStudentCoursesByEmail(email);
            return View(courses);
        }
    }
}




