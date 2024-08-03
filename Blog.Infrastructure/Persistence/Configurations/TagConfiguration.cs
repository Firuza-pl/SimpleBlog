using Blog.Domain.Entities.OrderAggregate;
using Blog.Domain.Entities.Tag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Blog.Infrastructure.Persistence.Configurations
{
    public class TagConfiguration
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(x => x.TagId);

            builder.Property(p => p.TagId).ValueGeneratedNever();
            builder.HasMany(p => p.ProductTags)
                .WithOne(p => p.Tag)
                .HasForeignKey(p => p.TagId);
        }
    }
}
