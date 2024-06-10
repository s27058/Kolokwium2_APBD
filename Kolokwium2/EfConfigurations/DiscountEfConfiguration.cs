using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class DiscountEfConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discount");

        builder.HasKey(d => d.IdDiscount);
        builder.Property(d => d.IdDiscount).ValueGeneratedOnAdd();
        builder.Property(d => d.Value).IsRequired();
        builder.Property(d => d.DateFrom).IsRequired();
        builder.Property(d => d.DateTo).IsRequired();
        
        builder.HasOne<Subscription>(s => s.IdSubscriptionNavigation)
            .WithMany(c => c.Discounts)
            .HasForeignKey(s => s.IdSubscription);
    }
}