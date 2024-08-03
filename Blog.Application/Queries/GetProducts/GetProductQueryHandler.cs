using AutoMapper;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductDTO>>
    {
        private readonly IDbConnection _dbConnection;
        public GetProductQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var sql = @"Select ProductId,
                    ProductCode,
                    ProductName,
                    Description,
                    ListPrice, 
                    Status,
                    CAST(CreationDate as date) as CreationDate ,  CAST(ModificationDate as date) as ModificationDate 
                    FROM produt where Status=1 order by ProductId desc";

            var query = await _dbConnection.QueryAsync<ProductDTO>(sql, cancellationToken);
            return query;
        }
    }

}
