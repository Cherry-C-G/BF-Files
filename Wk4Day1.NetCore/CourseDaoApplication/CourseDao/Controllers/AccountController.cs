using CourseDaoMVC.Model;
using CourseDaoMVC.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseDaoMVC.Controllers
{
    [Authorize]
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountDAO _accountDAO;
        public AccountController(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var accounts = _accountDAO.GetAllAccounts();
            return View(accounts);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            _accountDAO.AddAccount(account);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var account = _accountDAO.FindAccountById(id);
            return View(account);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            _accountDAO.UpdateAccount(account);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _accountDAO.DeleteAccount(id);
            return RedirectToAction("Index");
        }
    }

}
