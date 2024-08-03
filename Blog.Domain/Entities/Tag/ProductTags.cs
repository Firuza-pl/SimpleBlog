using Blog.Domain.Entities.ProductAggregate;
namespace Blog.Domain.Entities.Tag
{
    public class ProductTags
    {
        public Guid ProductTagId { get; set; }

        public Guid ProductId { get; set; }
        public Products Product { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        public ProductTags(Guid productTagId, Guid productId, Guid tagId)
        {
            ProductTagId = productTagId;
            ProductId = productId;
            TagId = tagId;
        }

        public void Edit(Guid productId, Guid tagId)
        {
            ProductId = productId;
            TagId = tagId;
        }

        public void Remove()
        {
            Tag.Status = Shared.Enums.TagStatus.Deleted;
        }
    }
}
