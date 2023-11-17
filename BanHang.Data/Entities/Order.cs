namespace BanHang.Data.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal TotalAmount { get; set; }

        public int Quantity { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}