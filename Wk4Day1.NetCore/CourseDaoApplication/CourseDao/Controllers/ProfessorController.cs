using CourseDaoApplication.Data;
using CourseDaoMVC.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CourseDaoMVC.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly IProfessorDAO _professorDAO;

        public ProfessorController(IProfessorDAO professorDAO)
        {
            _professorDAO = professorDAO;
        }

        //public IActionResult Index()
        //{
        //   // var professors = _professorDAO.GetAllProfessors();
        //    return View(Professor);
        //}

        public IActionResult Details(int id)
        {
            var professor = _professorDAO.FindProfessorById(id);
            return View(professor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _professorDAO.AddProfessor(professor);
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        public IActionResult Edit(int id)
        {
            var professor = _professorDAO.FindProfessorById(id);
            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _professorDAO.UpdateProfessor(professor);
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        public IActionResult Delete(int id)
        {
            var professor = _professorDAO.FindProfessorById(id);
            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _professorDAO.DeleteProfessor(id);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
