using Blog.Domain.Entities.ProjectAggregate;

namespace Blog.Domain.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        Task<Project> GetByIdAsync(Guid id);
        Task AddAsync(Project project);
    }
}
