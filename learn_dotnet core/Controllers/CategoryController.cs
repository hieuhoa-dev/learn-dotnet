using learn_dotnet_core.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using learn_dotnet_core.Models;
using learn_dotnet_core.DataAccess.Repository.IRepository;

namespace learn_dotnet_core.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICatogoryRepository _categoryRepo;

        public CategoryController(ICatogoryRepository db)
        {
            _categoryRepo = db;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepo.GetAll().ToList();

            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name.ToLower() == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Tên danh mục không được trùng với thứ tự hiển thị");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDb = _categoryRepo.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoryObj = _categoryRepo.Get(u => u.Id == id);
            if (categoryObj == null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var categoryObj = _categoryRepo.Get(u => u.Id == id);

            if (categoryObj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(categoryObj);
            _categoryRepo.Save();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
