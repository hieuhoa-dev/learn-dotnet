using learn_Razor_Pages.Data;
using learn_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace learn_Razor_Pages.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
