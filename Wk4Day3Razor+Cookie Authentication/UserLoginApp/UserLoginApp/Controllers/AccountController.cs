using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserLoginApp.Models;

namespace UserLoginApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountDAO _accountDAO;
        public AccountController(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _accountDAO.AddAccount(account);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _accountDAO.DeleteAccount(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            Account account = _accountDAO.GetAccountById(id);
            return View(account);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                _accountDAO.UpdateAccount(account);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid) return View();

            //verify the user credential
            if (username == "admin" && password == "123")
            {
                //if the user provide correct username and pwd
                //create the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Email, "admin@google.com"),
                    //new Claim("Department", "HR") //cannot access private page for now
                };

                var identity = new ClaimsIdentity(claims, "MyLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //Use the SignIn method in HttpContext, for now please follow the syntax
                await HttpContext.SignInAsync("MyLogin", principal);
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyLogin");
            return Redirect("/Account/Login");
        }
    }
}