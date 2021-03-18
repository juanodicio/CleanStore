using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(t => t.Brand)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(t => t.Description)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .IsRequired();

            builder.Property(t => t.Sku)
                .HasMaxLength(40);

            builder.Property(t => t.Stock)
                .HasDefaultValue(0)
                .IsRequired();
            
            builder.Property(t => t.Price)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.HasIndex(product => product.Name, "idx_prod_name");
        }
    }
}