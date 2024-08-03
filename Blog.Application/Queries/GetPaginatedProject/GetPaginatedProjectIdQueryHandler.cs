using Blog.Shared.DTOs;
using MediatR;
using System.Data;
using Dapper;

namespace Blog.Application.Queries.GetPaginatedProject
{
    public class GetPaginatedProjectIdQueryHandler : IRequestHandler<GetPaginatedProjectIdQuery, ProjectDTO>
    {
        private readonly IMediator _mediator;
        private readonly IDbConnection _dbConnection;

        public GetPaginatedProjectIdQueryHandler(IMediator mediator, IDbConnection dbConnection)
        {
            _mediator = mediator;
            _dbConnection = dbConnection;
        }

        public async Task<ProjectDTO> Handle(GetPaginatedProjectIdQuery projectIdQuery, CancellationToken cancellationToken)
        {
            var sql = @"
                        Select ProjectId,
                        Title,
                        Description,
                        CreationDate,
                        ModificationDate 
                        from Project
                        where isRemoved=0 and ProjectId=@ProjectId
                        Order By CreationDate Desc";

            var projectIdDTO = await _dbConnection.QuerySingleOrDefaultAsync<ProjectDTO>(sql,
                new { ProjectId = projectIdQuery.ProjectId });

            return projectIdDTO;
        }


    }
}
