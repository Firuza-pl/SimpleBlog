using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public class CreateOrderDetailsDTO
    {

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public DateTime ShippedDate { get; set; }
    }
}
