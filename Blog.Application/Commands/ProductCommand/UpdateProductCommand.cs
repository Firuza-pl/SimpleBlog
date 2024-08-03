using Blog.Shared.Enums;
using MediatR;

namespace Blog.Application.Commands.ProductCommand
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ListPrice { get; set; }
        //public ProductStatus Status { get; set; }

        public UpdateProductCommand(Guid productId, string productCode, string productName, string description, string listPrice)
        {
            ProductId = productId;
            ProductCode = productCode;
            ProductName = productName;
            Description = description;
            ListPrice = listPrice;
            //Status = status;
        }
    }
}
