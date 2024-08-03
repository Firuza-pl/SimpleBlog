using Blog.Domain.Entities.ProductAggregate;
namespace Blog.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Products> GetByIdAsync(Guid id);
        Task AddAsync(Products products);
    }
}
