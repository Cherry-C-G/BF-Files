using CourseDaoApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace CourseDaoApplication.Controller
{
    public class CourseController : ControllerBase
    {
        private readonly ICourseDAO _courseDAO;
        public CourseController(ICourseDAO courseDAO)
        {
            _courseDAO = courseDAO;
        }

        [HttpGet]
        [Route("/course")]
        public IActionResult GetCourses()
        {
            var courses = _courseDAO.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet]
        [Route("/course/{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _courseDAO.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        [Route("/course")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _courseDAO.AddCourse(course);
            return Created("", course);
        }

        //public IActionResult AddCourse(Course course)
        //{
        //    _courseDAO.AddCourse(course);
        //    return RedirectToAction("Index", "Course");
        //}

        public IActionResult UpdateCourse(Course course)
        {
            _courseDAO.UpdateCourse(course);
            return RedirectToAction("Index", "Course");
        }

        public IActionResult FindCourseById(int id)
        {
            var course = _courseDAO.FindCourseById(id);
            return View(course);
        }

        private IActionResult View(object course)
        {
            throw new NotImplementedException();
        }




    }
}
