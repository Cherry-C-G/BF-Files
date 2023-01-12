using CourseDao.Models;
using CourseDaoMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseDao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseDAO _courseDAO;

        //public HomeController(CourseDAO courseDAO)
        //{
        //    _courseDAO = courseDAO;
        //}

        private readonly ICourseDAO courseDAO;
        //public HomeController(ICourseDAO courseDAO)
        //{
        //    this.courseDAO = courseDAO;
        //}


        public HomeController(ILogger<HomeController> logger,ICourseDAO courseDao, CourseDAO courseDAO)
        {
            _logger = logger;
            this.courseDAO = courseDao;
            _courseDAO = courseDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public IActionResult Index()
        //{
        //    var courses = courseDAO.GetAllCourses();
        //    return View(courses);
        //}

    }
}