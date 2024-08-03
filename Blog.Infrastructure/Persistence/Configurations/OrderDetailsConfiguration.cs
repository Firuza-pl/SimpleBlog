using Blog.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.OrderDetailId);

            builder.Property(p => p.OrderDetailId).ValueGeneratedNever();
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            //18-total number of digits (left and right side of decimal point) , 2 -digits can be to the right of decimal point
            //example of decimal(18,2) is 1234567890123456.78 (78 is scale to the right is 2, 1234567890123456 is 16 digits)

            builder.HasOne(p => p.Products)
                .WithMany(p => p.OrderItem)
                .HasForeignKey(p => p.ProductsId);

            builder.HasOne(p => p.Order)
                .WithMany(p => p.OrderItem)
                .HasForeignKey(p => p.OrderId);
        }
    }
}
