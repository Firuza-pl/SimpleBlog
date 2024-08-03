using Blog.Application.Exceptions;
using Blog.Client.Pages.Project;
using Blog.Domain.Core;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.ProjectCommands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IProjectsRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if(project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            project.Edit(request.Title, request.Description);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
