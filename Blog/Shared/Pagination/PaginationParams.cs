using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Pagination
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 2;

        [Range(1, int.MaxValue)]
        public int ItemsCountPerPage { get; set; } = 5;
    }
}
