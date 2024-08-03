
using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public class CreateProjectDTO
    {
        [Required]
        [StringLength(20)]
        public string Title { get;  set; }

        [Required]
        [StringLength(100000)]
        public string Description { get; set; }
    }
}
