using Blog.Domain.Entities.OrderAggregate;
using Blog.Shared.DTOs;
using MediatR;

namespace Blog.Application.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<IEnumerable<OrderDetailsDTO>>
    {
        public GetOrderDetailsQuery()
        {
        }
    }
}
