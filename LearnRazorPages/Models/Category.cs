using System.ComponentModel.DataAnnotations;

namespace learn_Razor_Pages.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
        [MaxLength(30, ErrorMessage = "Tên danh mục không được vượt quá 30 ký tự")]
        public string Name { get; set; }


        [Range(1, 100, ErrorMessage = "Thứ tự hiển thị phải nằm trong khoảng 1-100")]
        public int DisplayOrder { get; set; }
    }
}
