using Blog.Domain.Entities.OrderAggregate;
namespace Blog.Domain.Repositories.Interfaces
{
    public interface IOrderDetailsRepository 
    {
        Task<OrderDetail> GetOrderById(Guid id);
        Task<Order> GetById(Guid id);
        Task AddAsync(OrderDetail orderDetails);
        Task AddOrderAsync(Order order);

    }
}
