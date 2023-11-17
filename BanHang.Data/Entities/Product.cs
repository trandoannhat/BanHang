namespace BanHang.Data.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Alias { get; set; }
        public string ProductCode { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }

        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public bool IsActive { get; set; }

        //liên kết tới bảng danh mục sản phẩm
        public int ProductCategoryID { get; set; }

        public Category ProductCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}