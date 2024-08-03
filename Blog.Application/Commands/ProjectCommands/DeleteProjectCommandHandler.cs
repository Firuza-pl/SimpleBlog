using Blog.Application.Exceptions;
using Blog.Client.Pages.Project;
using Blog.Domain.Core;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.ProjectCommands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IProjectsRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            project.Remove();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
