using MediatR;
namespace Blog.Application.Commands.ProdcutsTag
{
    public class DeleteProTagCommand : IRequest
    {
        public Guid ProductTagId { get; set; }
        public DeleteProTagCommand(Guid productTagId)
        {
            ProductTagId = productTagId;
        }
    }
}
