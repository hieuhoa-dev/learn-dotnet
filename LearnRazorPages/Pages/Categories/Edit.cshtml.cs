using learn_Razor_Pages.Data;
using learn_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace learn_Razor_Pages.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [BindProperty]
        public Category? Category { get; set; }

        public EditModel(ApplicationDBContext db)
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
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToPage("/Categories/Index");
            }
            return Page();
        }
    }
}
