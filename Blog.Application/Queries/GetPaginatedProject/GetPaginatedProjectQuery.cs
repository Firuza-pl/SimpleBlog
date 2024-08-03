using Blog.Common.Pagination;
using Blog.Shared.DTOs;
using MediatR;
namespace Blog.Application.Queries.GetPaginatedProject
{
    public class GetPaginatedProjectQuery : IRequest<IEnumerable<ProjectDTO>>
    {
        public GetPaginatedProjectQuery()
        {
                
        }
    }
}
