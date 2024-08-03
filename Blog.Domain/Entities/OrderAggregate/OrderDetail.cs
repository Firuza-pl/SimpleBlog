using Blog.Domain.Entities.ProductAggregate;

namespace Blog.Domain.Entities.OrderAggregate
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid ProductsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
        public Products Products { get; set; }

        public OrderDetail(Guid orderDetailId, Guid productsId, Guid orderId, int quantity, decimal unitPrice)
        {
            OrderDetailId = orderDetailId;
            ProductsId = productsId;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void Edit(Guid productsId, Guid orderId, int quantity, decimal unitPrice)
        {
            ProductsId = productsId;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void Remove()
        {
            Order.Status = Shared.Enums.OrderStatus.Canceled;
        }


    }
}
