using MediatR;

namespace Blog.Application.Commands.OrderDetails
{
    public class DeleteOrderDetailsCommand : IRequest
    {
        public Guid OrderDetailsId { get; set; }

        public DeleteOrderDetailsCommand(Guid orderDetailsId)
        {
            OrderDetailsId = orderDetailsId;
        }
    }
}
