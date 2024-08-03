using MediatR;
namespace Blog.Application.Commands.ProductCommand
{
    public class DeleteProductCommand: IRequest
    {
        public Guid ProductId { get; set; }
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
