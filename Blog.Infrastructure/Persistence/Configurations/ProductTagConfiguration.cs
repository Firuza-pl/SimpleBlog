using Blog.Domain.Entities.Tag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTags>
    {
        public void Configure(EntityTypeBuilder<ProductTags> builder)
        {
            builder.ToTable("ProductTags");
            builder.HasKey(p => p.ProductTagId);

            builder.Property(p => p.ProductId);
            builder.Property(p => p.TagId);

            builder.HasOne(p => p.Tag)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(p => p.TagId);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
