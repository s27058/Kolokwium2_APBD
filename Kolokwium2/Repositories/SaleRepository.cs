using EfCodeFirst.Context;
using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;

namespace WebApplication1.Repositories;

public interface ISaleRepository
{
    public Task<Client> GetClientAsync(int IdClient);
    public Task<List<Payment>> GetPayments(int IdClient);
    public Task<Subscription> GetSubscription(int IdSubcription);
    public Task<bool> ClientExistsAsync(int IdClient);
    public Task<bool> SubscriptionExistsAsync(int IdSubscription);
    public Task<bool> SubscriptionIsActiveAsync(int IdSubscription);
}

public class SaleRepository : ISaleRepository
{
    private readonly AppDbContext _context;

    public SaleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClientAsync(int IdClient)
    {
        return await _context.Clients.FindAsync(IdClient);
    }
    
    public async Task<List<Payment>> GetPayments(int IdClient)
    {
        return await _context.Payments.Where(p => p.IdClient == IdClient).ToListAsync();
    }
    
    public async Task<Subscription> GetSubscription(int IdSubcription)
    {
        return await _context.Subscriptions.FindAsync(IdSubcription);
    }
    
    public async Task<bool> ClientExistsAsync(int IdClient)
    {
        return await _context.Clients.AnyAsync(c => c.IdClient == IdClient);
    }
    
    public async Task<bool> SubscriptionExistsAsync(int IdSubscription)
    {
        return await _context.Subscriptions.AnyAsync(c => c.IdSubscription == IdSubscription);
    }
    public async Task<bool> SubscriptionIsActiveAsync(int IdSubscription)
    {
        return await _context.Subscriptions.AnyAsync(c => c.IdSubscription == IdSubscription && c.EndTime > DateTime.Now);
    }



}