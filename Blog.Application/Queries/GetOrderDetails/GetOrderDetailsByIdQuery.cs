using Blog.Shared.DTOs;
using MediatR;
namespace Blog.Application.Queries.GetOrderDetails
{
    public class GetOrderDetailsByIdQuery : IRequest<OrderDetailsDTO>
    {
        public Guid OrderDetailsId { get; set; }

        public GetOrderDetailsByIdQuery(Guid orderDetailsId)
        {
            OrderDetailsId = orderDetailsId;
        }
    }
}
