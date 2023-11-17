namespace BanHang.Data.Entities
{
    public class Menu : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Position { get; set; }
        public string SeoTitle { get; set; } = string.Empty;
        public string SeoDescription { get; set; } = string.Empty;
        public string SeoKeyword { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

        public List<New> News { get; set; }
        public List<Post> Posts { get; set; }
    }
}