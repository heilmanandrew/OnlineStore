using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreContext _ctx;

        public StoreRepository(StoreContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                       .OrderBy(p => p.Description)
                       .ToList();
        }

        public IEnumerable<Product> GetProductsByManufacturer(string manufacturer)
        {
            return _ctx.Products
                       .Where(p => p.Manufacturer == manufacturer)
                       .ToList();
        }
    }
}
