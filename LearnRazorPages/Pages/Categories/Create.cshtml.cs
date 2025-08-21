using learn_Razor_Pages.Data;
using learn_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace learn_Razor_Pages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Category Category { get; set; }
        //  Liên k?t d? li?u t? bi?u m?u

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Category = new Category();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Category);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToPage("/Categories/Index");
            }
            return Page();
        }
    }
}
