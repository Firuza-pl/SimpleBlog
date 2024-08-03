using Blog.Domain.Entities.Tag;
namespace Blog.Domain.Repositories.Interfaces
{
    public interface IProductTagsRepository
    {
        Task<ProductTags> GetProductTagByIdAsync(Guid id);
        Task<Tag> GetTagById(Guid id);
        Task AddAsync(ProductTags product);
        Task AddTagsAsync(Tag tags);
    }
}
