namespace BanHang.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }
        public Product Product { get; set; }
    }
}