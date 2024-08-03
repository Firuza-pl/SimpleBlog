using MediatR;

namespace Blog.Application.Commands.ProdcutsTag
{
    public class CreateProTagCommand : IRequest
    {
        public Guid ProductTagId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }

        public CreateProTagCommand(Guid productTagId, Guid productId, Guid tagId)
        {
            ProductTagId = productTagId;
            ProductId = productId;
            TagId = tagId;
        }

    }
}
