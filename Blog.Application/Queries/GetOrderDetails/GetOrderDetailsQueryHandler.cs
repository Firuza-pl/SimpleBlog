using AutoMapper;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, IEnumerable<OrderDetailsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;

        public GetOrderDetailsQueryHandler(IMapper mapper, IDbConnection dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<OrderDetailsDTO>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetailAll = await _dbConnection.QueryAsync<OrderDetailsDTO>(
                @"Select OrderDetailId,
                ProductsId,
                O.OrderId,
				O.ShippedDate,
				O.Status,
                Quantity,
                UnitPrice from OrderDetails 
				OD inner join [BlogDatabase].[dbo].[Order] O 
				 on OD.OrderId=O.OrderId
				 ORDER BY OrderDetailId DESC"
                );

            return orderDetailAll;
        }

     
    }
}
