using EfCodeFirst.Models;

namespace WebApplication1.DTOs;

public class ClientWithSubsDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<SubscriptionDTO> Subscriptions { get; set; }
}