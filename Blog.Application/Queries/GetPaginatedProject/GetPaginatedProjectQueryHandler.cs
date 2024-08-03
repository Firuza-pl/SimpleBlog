using AutoMapper;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetPaginatedProject
{
    public class GetPaginatedProjectQueryHandler : IRequestHandler<GetPaginatedProjectQuery, IEnumerable<ProjectDTO>>
    {
        // PaginatedList<ProjectDTO> where we want to paginate list of ProjectDto objects

        private readonly IDbConnection _dbConnection;

        public GetPaginatedProjectQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ProjectDTO>> Handle(GetPaginatedProjectQuery request, CancellationToken cancellationToken)
        {
            var sql = @"
                        Select ProjectId,
                        Title,
                        Description,
                        CreationDate,
                        ModificationDate 
                        from Project
                        where isRemoved=0
                        Order By CreationDate Desc";

            var query = await _dbConnection.QueryAsync<ProjectDTO>(sql, cancellationToken);
            return query;
        }
    }
}
