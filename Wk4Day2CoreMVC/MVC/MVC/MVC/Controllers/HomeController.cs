using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    //[Route("/api")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("index")] //-> get,, post, patch, delete, put..
        public IActionResult Index()
        {
            return View();
            //return Ok();
        }
        
        [HttpPost("welcome/{id}")]
        public string welcome3(int id)
        {
            return "welcome"+id;
        }
        

        [HttpPost("welcome1")]
        public string welcome(int id, string name) {
            return "welcome" +id+"  "+name;
        }
        

        [HttpPost("welcome")]
        public string welcome(Student e)
        {

            return "welcome" + e.firstname + "  " + e.lastname;
        }

        /*
        [HttpPost("welcome")]
        public GetStudentByIdResponse GetStudentById([FromBody] GetStudentByIdRequest r)
        {
            //fetch student --> service
            GetStudentByIdResponse r =//status, exception, student
            return r;
        }
        *


        [HttpPost("bye")]
        public IActionResult bye()
        {
            Student s = new Student()
            {
                firstname = "slez",
                lastname = "p",
                age = 11
            };


            Student s1 = new Student()
            {
                firstname = "slez",
                lastname = "p",
                age = 11
            };

            return View(s) ;
        }
        /*
        [HttpPost("welcome")]
        public string welcome1([FromBody]Student e)
        {

            return "welcome" + e.firstname + "  " + e.lastname;
        }
        */

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }


        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}