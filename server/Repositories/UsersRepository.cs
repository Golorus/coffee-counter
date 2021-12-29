using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using server.Models;

namespace server.Repositories
{

    public interface IUsersRepository
    {
        User GetUserById(string id);
        User GetUserByName(string Name);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public UsersRepository(ICoffeeListDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(
                settings.ConnectionString
            );
            var mongoDatabase = mongoClient.GetDatabase(
                settings.DatabaseName
            );
            _userCollection = mongoDatabase.GetCollection<User>(
                settings.UserCollectionName);
        }
        public User GetUserById(string id)
        {
            User user = _userCollection.Find(x => x.Id == id).First();
            return user;
        }
        public User GetUserByName(string Name)
        {
            var filter = Builders<User>.Filter.Where(x => x.Name == Name);
            User user = _userCollection.Find(filter).First();
            Console.Write(user);
            return user;
        }
    }
}