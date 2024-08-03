using Blog.Domain.Entities.ProductAggregate;
using Blog.Domain.Repositories.Interfaces;
using Blog.Infrastructure.Persistence;
using Blog.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Products> GetByIdAsync(Guid id)
        {
            var product = await _applicationDbContext.Products
                .Where(p => p.Status == ProductStatus.Created)
                .SingleOrDefaultAsync(p => p.ProductId == id);

            return product;
        }

        public async Task AddAsync(Products products)
        {
            await _applicationDbContext.Products.AddAsync(products);
        }

    }
}
