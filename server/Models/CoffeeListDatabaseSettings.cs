using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public interface ICoffeeListDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CoffeeCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string PurchaseCollectionName { get; set; }
        decimal actualPrice { get; set; }
    }

    public class CoffeeListDatabaseSettings : ICoffeeListDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CoffeeCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;
        public string PurchaseCollectionName { get; set; } = null!;
        public decimal actualPrice { get; set; }
    }
}