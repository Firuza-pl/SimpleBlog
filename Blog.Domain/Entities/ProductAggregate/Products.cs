using Blog.Domain.Entities.OrderAggregate;
using Blog.Domain.Entities.Tag;
using Blog.Shared.Enums;

namespace Blog.Domain.Entities.ProductAggregate
{
    public class Products
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ListPrice { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public List<OrderDetail> OrderItem { get; private set; }
        public List<ProductTags> ProductTags { get; private set; }

        private Products()
        {
            OrderItem = new List<OrderDetail>();
        }

        public Products(Guid productId, string productCode, string productName, string description, string listPrice, ProductStatus productStatus=ProductStatus.Created )
        {
            ProductId = productId;
            ProductCode = productCode;
            ProductName = productName;
            Description = description;
            ListPrice = listPrice;
            Status = productStatus;
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
            OrderItem = new List<OrderDetail>();
        }

        public void Edit(string productCode, string productName, string description, string listPrice, ProductStatus productStatus=ProductStatus.Created)
        {
            ProductCode = productCode;
            ProductName = productName;
            Description = description;
            ListPrice = listPrice;
            Status = productStatus;
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }

        public void Remove()
        {
            Status = ProductStatus.Deleted;
        }

    }
}
