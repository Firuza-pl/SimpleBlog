using Blog.Domain.Core;
using Blog.Domain.Entities.ProjectAggregate;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.ProjectCommands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IProjectsRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.ProjectId, request.Title, request.Description);

            await _projectRepository.AddAsync(project);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
