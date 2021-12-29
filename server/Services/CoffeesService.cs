using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public interface ICoffeesService
    {
        List<Coffee> GetCoffees();
        Coffee addCoffee( string Name);
    }

    public class CoffeesService : ICoffeesService
    {
        private readonly ICoffeesRepository _coffeesrepository;
        private readonly IUsersRepository _userrepository;
        private readonly ICoffeeListDatabaseSettings _settings;

        public CoffeesService(ICoffeesRepository coffeesrepository, IUsersRepository userrepository, ICoffeeListDatabaseSettings settings)
        {
            _coffeesrepository = coffeesrepository;
            _userrepository = userrepository;
            _settings = settings;
        }

        public  List<Coffee> GetCoffees()
        {
           return _coffeesrepository.GetCoffees();
        }
        public Coffee addCoffee(string Name)
        {
            decimal _price = _settings.actualPrice;
            User user = _userrepository.GetUserByName(Name);
            Coffee coffee = new Coffee
            {
                DrunkByUser = user,
                price = _price,
                TimeStamp = System.DateTime.Now,
            };
           return _coffeesrepository.addCoffee(coffee);
        }
    }
}


