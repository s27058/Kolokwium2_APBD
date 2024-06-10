using System.Data.SqlTypes;

namespace EfCodeFirst.Models;

public class Subscription
{
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public int RenewalPeriod { get; set; }
    public DateTime EndTime { get; set; }
    public SqlMoney Price { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<Discount> Discounts { get; set; }

}