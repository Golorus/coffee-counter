using server.Repositories;

namespace server.Services


{
    public class FinanceService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public FinanceService(IPurchaseRepository purchaseRepository, ICoffeesRepository _coffeeRepository, IUsersRepository _userRepository)
        {
            _purchaseRepository = purchaseRepository;


        }
    }
}