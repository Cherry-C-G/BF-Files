using FormExample.DAL;
using FormExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormExample.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDao _categoryDao; 
        public CategoryController(CategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        [HttpGet]
        public IActionResult Index()
        {
           List<Category> categories =  _categoryDao.GetAllCategories();
            return View(categories);
        }

        //an end point to reach the page
        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create( Category newCategory)
        {
            // we can do validation at here as well
            _categoryDao.AddCategory(newCategory);
            return RedirectToAction("Index"); //after adding new category go back to index page
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _categoryDao.GetAllCategories().Where(c => c.Id == id).FirstOrDefault();
            if(model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Category updatedCategory)
        {
            _categoryDao.UpdateCategory(updatedCategory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _categoryDao.GetAllCategories().Where(c=>c.Id == id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _categoryDao.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}
