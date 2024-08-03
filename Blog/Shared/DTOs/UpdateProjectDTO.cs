using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public  class UpdateProjectDTO
    {
        [Required]
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
