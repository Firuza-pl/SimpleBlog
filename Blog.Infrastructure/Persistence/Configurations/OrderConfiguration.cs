using Blog.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.OrderId);

            builder.Property(p => p.OrderId).ValueGeneratedNever();
            builder.HasMany(p=>p.OrderItem)
                .WithOne(p=>p.Order)
                .HasForeignKey(p=>p.OrderId);
        }
    }
}
