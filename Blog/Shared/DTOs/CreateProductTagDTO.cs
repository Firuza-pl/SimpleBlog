using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.DTOs
{
    public class CreateProductTagDTO
    {
        public Guid ProductDetailsId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }
    }
}
