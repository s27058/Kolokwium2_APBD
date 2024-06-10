using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class PaymentEfConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(p => p.IdPayment);
        builder.Property(p => p.IdPayment).ValueGeneratedOnAdd();
        builder.Property(p => p.Date).IsRequired();
        
        builder.HasOne<Subscription>(s => s.IdSubscriptionNavigation)
            .WithMany(c => c.Payments)
            .HasForeignKey(s => s.IdSubscription);
        
        builder.HasOne<Client>(s => s.IdClientNavigation)
            .WithMany(c => c.Payments)
            .HasForeignKey(s => s.IdClient);
    }
}