using Blog.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.DTOs
{
    public class ProductTagsDTO
    {
        public Guid ProductTagId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }
        //for product
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ListPrice { get; set; }
        public ProductStatus ProStatus { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }
        //for tag
        public string Name { get; set; }
        public TagStatus TagStatus { get; set; }
    }
}
