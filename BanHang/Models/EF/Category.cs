using BanHang.Models.Common;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BanHang.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<News>();
            this.Posts = new HashSet<Post>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được bỏ trống")]
        [StringLength(150)]
        public string Title { get; set; }

        public string? Alias { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }

        [StringLength(250)]
        public string? SeoTitle { get; set; }

        [StringLength(550)]
        public string? SeoDescription { get; set; }

        [StringLength(250)]
        public string? SeoKeyword { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<News> News { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}