using Blog.Domain.Entities.Tag;
using Blog.Domain.Repositories.Interfaces;
using Blog.Infrastructure.Persistence;
using Blog.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class ProductTagRepository : IProductTagsRepository
    {
        private readonly ApplicationDbContext _applicationContext;
        public ProductTagRepository(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        public async Task AddAsync(ProductTags proTags)
        {
            await _applicationContext.AddAsync(proTags);
        }

        public async Task AddTagsAsync(Tag tags)
        {
          await _applicationContext.Tags.AddAsync(tags);
        }

        public async Task<ProductTags> GetProductTagByIdAsync(Guid id)
        {
            var proTags = await _applicationContext.ProductTags
             .Include(p => p.Product)
             .Include(p => p.Tag)
             .Where(p => p.ProductTagId == id && p.Tag.Status == TagStatus.Created)
             .SingleOrDefaultAsync(p => p.ProductTagId == id); // Assuming you want a single result

            return proTags;
        }

        public async Task<Tag> GetTagById(Guid id)
        {
            var tags = await _applicationContext.Tags
             .Where(p => p.TagId == id && p.Status == TagStatus.Created)
             .SingleOrDefaultAsync(p => p.TagId == id); // Assuming you want a single result

            return tags;
        }
    }
}
