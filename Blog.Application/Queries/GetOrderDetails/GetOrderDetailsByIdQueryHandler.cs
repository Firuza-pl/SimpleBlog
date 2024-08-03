using AutoMapper;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetOrderDetails
{
    public class GetOrderDetailsByIdQueryHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderDetailsDTO>
    {
        private readonly IDbConnection _dbConnection;

        public GetOrderDetailsByIdQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<OrderDetailsDTO> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var orderId = await _dbConnection.QuerySingleOrDefaultAsync<OrderDetailsDTO>(
                @"Select OrderDetailId,
                ProductsId,
                 O.OrderId,
				O.ShippedDate,
				O.Status,
                Quantity,UnitPrice
                 from OrderDetails OD
				 inner join [BlogDatabase].[dbo].[Order] O 
				 on OD.OrderId=O.OrderId where OrderDetailId=@orderDetailId",
                new { orderDetailId = request.OrderDetailsId }
                );

            return orderId;
        }

    }
}
