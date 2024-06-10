using EfCodeFirst.EfConfigurations;
using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Context;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Discount> Discounts { get; set; }


    public AppDbContext() {}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder
    //         .UseSqlServer(
    //             "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True")
    //         .LogTo(Console.WriteLine, LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEfConfiguration());
        modelBuilder.ApplyConfiguration(new SaleEfConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionEfConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentEfConfiguration());
        modelBuilder.ApplyConfiguration(new DiscountEfConfiguration());
    }
}