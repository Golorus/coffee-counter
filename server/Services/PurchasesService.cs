using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public interface IPurchasesService
    {
        Task<Purchase> AddPurchase(string Name, decimal money);
        Task<IEnumerable<Purchase>> GetPurchases();
        Task<IEnumerable<Purchase>> GetPurchasesByUserName(string Name);
    }

    public class PurchasesService : IPurchasesService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IUsersRepository _userrepository;
        private readonly ICoffeeListDatabaseSettings _settings;

        public PurchasesService(IPurchaseRepository purchaseRepository, IUsersRepository userrepository, ICoffeeListDatabaseSettings settings)
        {
            _purchaseRepository = purchaseRepository;
            _userrepository = userrepository;
            _settings = settings;
        }
        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            var response = await _purchaseRepository.GetPurchases();
            return response;
        }
        public async Task<IEnumerable<Purchase>> GetPurchasesByUserName(string Name)
        {
            var user = _userrepository.GetUserByName(Name);

            var response = await _purchaseRepository.GetPurchasesByUserId(user.Id);
            return response;
        }
        public async Task<Purchase> AddPurchase(string Name, decimal money)
        {
            var user = _userrepository.GetUserByName(Name);
            var purchase = new Purchase
            {
                Purchaser = user,
                price = money,
                TimeStamp = System.DateTime.Now,
            };
            var response = await _purchaseRepository.AddPurchase(purchase);
            return response;
        }

    }
}
