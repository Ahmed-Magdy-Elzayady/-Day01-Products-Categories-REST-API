using Day01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day01.Data.Configrations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(i => i.Category)
                .WithMany(o => o.Products)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired();
        }
    }
}
