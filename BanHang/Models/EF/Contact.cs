using BanHang.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BanHang.Models.EF
{
    [Table("tb_Contact")]
    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Tên gọi")]
        [StringLength(150, ErrorMessage = "Chiều dài không được vượt quá 150 ký tự")]
        public string Name { get; set; }

        public string? Website { get; set; }

        [Display(Name = "Hòm thư")]
        [StringLength(150, ErrorMessage = "Chiều dài không được vượt quá 150 ký tự")]
        public string? Email { get; set; }

        public string? Message { get; set; }
        public bool? IsRead { get; set; } = true;
    }
}