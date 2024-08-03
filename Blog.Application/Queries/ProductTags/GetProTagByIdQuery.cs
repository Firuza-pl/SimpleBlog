using Blog.Domain.Entities.Tag;
using Blog.Shared.DTOs;
using MediatR;

namespace Blog.Application.Queries.ProductTags
{
    public class GetProTagByIdQuery : IRequest<ProductTagsDTO>
    {
        public Guid ProductTagId { get; set; }
        public GetProTagByIdQuery(Guid productTagId)
        {
            ProductTagId = productTagId;
        }
    }
}
