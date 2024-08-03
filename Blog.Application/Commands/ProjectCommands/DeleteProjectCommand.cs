using MediatR;

namespace Blog.Application.Commands.ProjectCommands
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public DeleteProjectCommand(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
