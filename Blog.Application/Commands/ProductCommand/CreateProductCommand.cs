using Blog.Shared.Enums;
using MediatR;

namespace Blog.Application.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ListPrice { get; set; }
        public ProductStatus Status { get; set; }

        public CreateProductCommand(Guid productId, string productCode, string productName, string description, string listPrice, ProductStatus status = ProductStatus.Created)
        {
            ProductId = productId;
            ProductCode = productCode;
            ProductName = productName;
            Description = description;
            ListPrice = listPrice;
            Status = status;
        }
    }
}
