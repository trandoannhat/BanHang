using BanHang.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//using System.Web.Mvc;

namespace BanHang.Models.EF
{
    [Table("tb_News")]
    public class News : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề tin không được trống")]
        [StringLength(150)]
        public string Title { get; set; }

        public string? Alias { get; set; }
        public int? CategoryID { get; set; }

        public string? Description { get; set; }

        //[AllowHtml]//cho phép luu html
        public string? Detail { get; set; }

        public string? Image { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoKeyword { get; set; }
        public bool IsActive { get; set; } = true;

        //liên kết tới bảng category
        public virtual Category Category { get; set; }
    }
}