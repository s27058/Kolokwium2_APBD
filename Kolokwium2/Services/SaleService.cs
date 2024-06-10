using EfCodeFirst.Models;
using WebApplication1.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public interface ISaleService
{
    public Task<ClientWithSubsDTO> GetClientsWithSubscriptionsAsync(int IdClient);
}

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository salerRepository)
    {
        _saleRepository = salerRepository;
    }

    public async Task<ClientWithSubsDTO> GetClientsWithSubscriptionsAsync(int IdClient)
    {
        var client = await _saleRepository.GetClientAsync(IdClient);
        var payments = await _saleRepository.GetPayments(IdClient);
        var subscriptionList = new List<SubscriptionDTO>();
        foreach (Payment payment in payments)
        {
            var subscription = await _saleRepository.GetSubscription(payment.IdSubscription);
            if (!subscriptionList.Any(s => s.IdSubscription == subscription.IdSubscription))
            {
                subscriptionList.Add(new SubscriptionDTO()
                {
                    IdSubscription = subscription.IdSubscription,
                    Name = subscription.Name,
                    Price = subscription.Price
                });
            }
            else
            {
                var s2 = subscriptionList.Find(s => s.IdSubscription == subscription.IdSubscription);
                s2.Price += subscription.Price;
            }
        }

        var results = new ClientWithSubsDTO()
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone,
            Subscriptions = subscriptionList
        };
        return results;
    }

    public async Task<bool> SaveClientPayment(int IdClient, int IdSubscription, Payment payment)
    {
        if (!await _saleRepository.ClientExistsAsync(IdClient)) return false;
        if (!await _saleRepository.SubscriptionExistsAsync(IdSubscription)) return false;
        if (!await _saleRepository.SubscriptionIsActiveAsync(IdSubscription)) return false;
        var subscription = await _saleRepository.GetSubscription(IdSubscription);
        var price = 0;
        return true;
    }


}