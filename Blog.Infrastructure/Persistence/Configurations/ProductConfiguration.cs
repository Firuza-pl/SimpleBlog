using Blog.Domain.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Produt");
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductId).ValueGeneratedNever();

            //HasMany-shows that the Products entity has many OrderItem entities.
            builder.HasMany(p => p.OrderItem).
                //WithOne-specifies that the OrderItem entity has a reference back to a single Product.
                WithOne(p => p.Products).
                //HasForeignKey-specifies the foreign key property (ProductsId) that links the OrderItem entity to the Products entity.
                HasForeignKey(p => p.ProductsId);
        }
    }
}
