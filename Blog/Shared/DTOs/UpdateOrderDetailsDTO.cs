using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public class UpdateOrderDetailsDTO
    {
        [Required]
        public Guid OrderDetailId { get; set; }
        public string ProductCode { get; set; }

        [Required]
        public Guid ProductsId { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
