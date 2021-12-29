using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using server.Models;

namespace server.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> AddPurchase(Purchase purchase);
        Task<IEnumerable<Purchase>> GetPurchases();
        Task<IEnumerable<Purchase>> GetPurchasesByUserId(string id);
    }

    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IMongoCollection<Purchase> _purchaseCollection;

        public PurchaseRepository(ICoffeeListDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(
                settings.ConnectionString
            );
            var mongoDatabase = mongoClient.GetDatabase(
                settings.DatabaseName);

            _purchaseCollection = mongoDatabase.GetCollection<Purchase>(
                "Purchases");

        }
        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            List<Purchase> response = await _purchaseCollection.Find(x => true).ToListAsync();
            return response;
        }
        public async Task<IEnumerable<Purchase>> GetPurchasesByUserId(string id)
        {
            var filter = Builders<Purchase>.Filter.Eq("Purchase.Id", id);
            List<Purchase> response = await _purchaseCollection.Find(filter).ToListAsync();
            return response;
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            await _purchaseCollection.InsertOneAsync(purchase);
            return purchase;
        }
    }
}