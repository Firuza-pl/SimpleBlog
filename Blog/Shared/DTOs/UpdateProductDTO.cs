using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public class UpdateProductDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ListPrice { get; set; }
    }
}
