using Blog.Shared.Enums;
namespace Blog.Shared.DTOs
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ListPrice { get; set; }
        public ProductStatus Status { get; set; }
        public string CreationDate { get;  set; }
        public string ModificationDate { get;  set; }
    }
}
