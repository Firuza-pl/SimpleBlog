using MediatR;

namespace Blog.Application.Commands.ProjectCommands
{
    public class CreateProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateProjectCommand(Guid projectId, string title, string description)
        {
            ProjectId = projectId;
            Title = title;
            Description = description;
        }
    }
}
