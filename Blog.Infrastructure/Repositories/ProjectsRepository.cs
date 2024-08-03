using Blog.Domain.Entities.ProjectAggregate;
using Blog.Domain.Repositories.Interfaces;
using Blog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProjectsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            var project = await _applicationDbContext.Projects
                .Where(p => p.isRemoved == false)
                .SingleOrDefaultAsync(p => p.ProjectId == id);

            return project;
        }

        public async Task AddAsync(Project project)
        {
            await _applicationDbContext.Projects.AddAsync((project));
        }

       
    }
}
