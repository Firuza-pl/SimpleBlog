﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.DTOs
{
    public class CreateEmailMessageDTO
    {
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(10000)]
        public string Message { get; set; }
    }
}
