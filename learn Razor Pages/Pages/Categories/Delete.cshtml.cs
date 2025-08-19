using learn_Razor_Pages.Data;
using learn_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace learn_Razor_Pages.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [BindProperty]
        public Category? Category { get; set; }

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category = _db.Categories.Find(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                TempData["Error"] = "Category not found";
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToPage("/Categories/Index");
        }
    }
}
