
using Blog.Shared.Enums;

namespace Blog.Shared.DTOs
{
    public class OrderDetailsDTO
    {
        public Guid OrderDetailId { get; set; }
        public Guid ProductsId { get; set; }
        public Guid OrderId { get; set; }
        public string ShippedDate { get; set; }
        public OrderStatus Satus { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
