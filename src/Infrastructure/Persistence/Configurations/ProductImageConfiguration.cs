using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductImageConfiguration: IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .HasDefaultValue("");
            
            builder.Property(t => t.Url)
                .HasMaxLength(240)
                .IsRequired();
        }
    }
}