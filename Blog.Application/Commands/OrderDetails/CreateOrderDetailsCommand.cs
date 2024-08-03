using MediatR;
namespace Blog.Application.Commands.OrderDetails
{
    public class CreateOrderDetailsCommand : IRequest
    {
        public Guid OrderDetailId { get; set; }
        public Guid ProductsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ShippedDate { get; set; }

        public CreateOrderDetailsCommand(Guid orderDetailId, Guid productsId,int quantity, decimal unitPrice, DateTime shippedDate)
        {
            OrderDetailId = orderDetailId;
            ProductsId = productsId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            ShippedDate = shippedDate;
        }
    }
}
