using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public class UpdatePostDTO
    {
        [Required]
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Content { get; set; }
    }
}
