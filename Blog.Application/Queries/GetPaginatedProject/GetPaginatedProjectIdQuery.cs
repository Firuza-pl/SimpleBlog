using Blog.Shared.DTOs;
using MediatR;

namespace Blog.Application.Queries.GetPaginatedProject
{
    public class GetPaginatedProjectIdQuery : IRequest<ProjectDTO>
    {
        public Guid ProjectId { get; set; }
        public GetPaginatedProjectIdQuery(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
