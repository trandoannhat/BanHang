namespace BanHang.Data.Entities
{
    public class Contact : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public bool? IsRead { get; set; }
    }
}