using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controller;


[Route("/api/")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [Route("clients")]
    [HttpGet]
    public async Task<IActionResult> GetClientsWithSubscriptionsAsync([FromQuery] int IdClient)
    {
        var clients = await _saleService.GetClientsWithSubscriptionsAsync(IdClient);
        return Ok(clients);
    }
    
}