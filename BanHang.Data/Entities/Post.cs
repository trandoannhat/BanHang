namespace BanHang.Data.Entities
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }

        public string Detail { get; set; }
        public string Image { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public bool IsActive { get; set; } = true;

        //liên kết tới bảng danh mục menu
        public int CategoryID { get; set; }

        public Menu Category { get; set; }
    }
}