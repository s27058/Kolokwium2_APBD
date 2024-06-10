using System.Data.SqlTypes;

namespace WebApplication1.DTOs;

public class SubscriptionDTO
{
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public SqlMoney Price { get; set; }
}