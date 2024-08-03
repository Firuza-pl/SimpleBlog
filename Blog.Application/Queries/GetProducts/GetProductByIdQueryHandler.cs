using AutoMapper;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetProducts
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;
        public GetProductByIdQueryHandler(IMapper mapper, IDbConnection dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery getProduct, CancellationToken cancellationToken)
        {
            var productDTO = await _dbConnection.QuerySingleOrDefaultAsync<ProductDTO>(
                @"
                    Select ProductId,
                    ProductCode,
                    ProductName,
                    Description,
                    ListPrice, 
                    Status,
                    CAST(CreationDate as date) as CreationDate ,  CAST(ModificationDate as date) as ModificationDate
                    FROM produt where ProductId=@ProductId and Status=1",
                    new { ProductId = getProduct.ProductId });

                     return productDTO;
        }
    }
}
