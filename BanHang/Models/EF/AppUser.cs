using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BanHang.Models.EF
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        public string? FullName { set; get; } = null;

        [MaxLength(255)]
        public string? Address { set; get; } = null;

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }

        [DataType(DataType.Date)]
        public DateTime? CreatedAt { set; get; } = DateTime.UtcNow;
    }
}