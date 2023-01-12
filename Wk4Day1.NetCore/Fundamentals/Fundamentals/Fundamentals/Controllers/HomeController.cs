using Fundamentals.Models;
using Fundamentals.Models.Storage;
using Fundamentals.Models.Storage.DBModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fundamentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Car _vehicle;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, Car vehicle, IConfiguration configuration)
        {
            _logger = logger;
            _vehicle = vehicle;
            _configuration = configuration;
        }

        public IActionResult Index()
        {


            return View();
        }

        public string testConfig()
        {
            _configuration.GetSection("hello"); //-> world

            UserConfigModel u = new UserConfigModel();
            _configuration.GetSection(UserConfigModel.UserConfig).Bind(u);
            return u.Name+"  "+u.UserId;
        }

        public string vehicle()
        {
            
            return _vehicle.move();
        }
    }
}