using System.ComponentModel.DataAnnotations;

namespace ViewModels.Catalog.Menus
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên menu")]
        public string Title { get; set; } = string.Empty;

        public string Alias { get; set; } = string.Empty;

        [Display(Name = "Ghi chú")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Thứ tự")]
        public int? Position { get; set; }

        [Display(Name = "Tiêu đề Seo")]
        public string SeoTitle { get; set; } = string.Empty;

        [Display(Name = "Ghi chú Seo")]
        public string SeoDescription { get; set; } = string.Empty;

        [Display(Name = "Từ khóa Seo")]
        public string SeoKeyword { get; set; } = string.Empty;

        [Display(Name = "Hiển thị")]
        public bool? IsActive { get; set; }
    }
}