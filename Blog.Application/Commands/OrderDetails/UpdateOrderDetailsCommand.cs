using MediatR;
namespace Blog.Application.Commands.OrderDetails
{
    public class UpdateOrderDetailsCommand : IRequest
    {
        public Guid OrderDetailId { get; set; }
        public Guid ProductsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ShippedDate { get; set; }


        public UpdateOrderDetailsCommand(Guid productsId, Guid orderId, int quantity, decimal unitPrice, DateTime shippedDate)
        {
            ProductsId = productsId;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            ShippedDate = shippedDate;
        }
    }
}
