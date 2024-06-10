using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class SaleEfConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");

        builder.HasKey(s => s.IdSale);
        builder.Property(s => s.IdSale).ValueGeneratedOnAdd();
        builder.Property(s => s.CreatedAt).IsRequired();
        
        builder.HasOne<Client>(s => s.IdClientNavigation)
            .WithMany(c => c.Sales)
            .HasForeignKey(s => s.IdClient);
        
        builder.HasOne<Subscription>(s => s.IdSubscriptionNavigation)
            .WithMany(c => c.Sales)
            .HasForeignKey(s => s.IdSubscription);
    }
}