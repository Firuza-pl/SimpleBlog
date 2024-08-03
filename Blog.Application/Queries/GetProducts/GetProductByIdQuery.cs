using Blog.Shared.DTOs;
using MediatR;

namespace Blog.Application.Queries.GetProducts
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid ProductId { get; set; }
        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
