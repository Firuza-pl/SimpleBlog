
using Blog.Domain.Entities.OrderAggregate;
using Blog.Shared.Enums;

namespace Blog.Domain.Entities.OrderAggregate
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public ICollection<OrderDetail> OrderItem { get; set; }
        //private Order()
        //{
        //    OrderItem = new List<OrderDetail>();
        //}
        public Order(Guid orderId, DateTime shippedDate, OrderStatus status = OrderStatus.Active)
        {
            OrderId = orderId;
            Status = status;
            OrderDate = DateTime.Now;
            ShippedDate = shippedDate;
            // OrderItem = orderItem;
        }
        public void Edit(DateTime shippedDate)
        {
            Status = OrderStatus.Active;
            OrderDate = DateTime.UtcNow;
            ShippedDate = shippedDate;
        }

        public void Remove()
        {
            Status = OrderStatus.Canceled;
        }

    }
}
