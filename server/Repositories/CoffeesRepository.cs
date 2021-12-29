using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using server.Models;

namespace server.Repositories
{
    public interface ICoffeesRepository
    {
        Coffee addCoffee(Coffee coffee);
        List<Coffee> GetCoffees();
    }

    public class CoffeesRepository : ICoffeesRepository
    {
        private readonly IMongoCollection<Coffee> _coffeeCollection;

        public CoffeesRepository(ICoffeeListDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(
                settings.ConnectionString
            );
            var mongoDatabase = mongoClient.GetDatabase(
                settings.DatabaseName);

            _coffeeCollection = mongoDatabase.GetCollection<Coffee>(
                "Coffees");

        }
        public List<Coffee> GetCoffees()
        {
            var test = _coffeeCollection.Find(_ => true).ToList();
            return test;
        }
        public Coffee addCoffee(Coffee coffee)
        {
            _coffeeCollection.InsertOneAsync(coffee);
            return coffee;
        }
    }

}