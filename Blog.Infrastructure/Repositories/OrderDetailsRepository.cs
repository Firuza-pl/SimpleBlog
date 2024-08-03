using Blog.Domain.Entities.OrderAggregate;
using Blog.Domain.Repositories.Interfaces;
using Blog.Infrastructure.Persistence;
using Blog.Shared.Enums;
using Microsoft.EntityFrameworkCore;
namespace Blog.Infrastructure.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderDetailsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<OrderDetail> GetOrderById(Guid id)
        {
            var oderDetail = await _applicationDbContext.OrderDetails.Include(p => p.Order)
                .Where(p => p.Order.Status == OrderStatus.Active).SingleOrDefaultAsync(p => p.OrderDetailId == id);

            return oderDetail;
        }


        public async Task<Order> GetById(Guid id)
        {
            var order = await _applicationDbContext.Orders
                .Where(p => p.Status == OrderStatus.Active).SingleOrDefaultAsync(p => p.OrderId == id);

            return order;
        }


        public async Task AddAsync(OrderDetail orderDetails)
        {
            await _applicationDbContext.OrderDetails.AddAsync(orderDetails);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _applicationDbContext.Orders.AddAsync(order);
        }

    }
}
