namespace BanHang.Data.Entities
{
    public class Adv : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int? Type { get; set; }
        public string Link { get; set; } = string.Empty;
    }
}