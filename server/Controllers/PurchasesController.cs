
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using server.Models;
    using server.Services;
    using System.Text.Json;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PurchasesController : ControllerBase
    {
        private readonly PurchasesService _purchasesService;
        public PurchasesController(PurchasesService service)
        {
            _purchasesService = service;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            var response = await _purchasesService.GetPurchases();
            return response;
        }

        [HttpPost]
        public async Task<Purchase> AddAsync(Purchase purchase)
        {
            var response = await _purchasesService.AddPurchase(purchase.Purchaser.Name,purchase.price);
            return response;
        }
    }
}
