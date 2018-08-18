using System.Collections.Generic;
using OnlineStore.Data.Entities;

namespace OnlineStore.Data
{
    public interface IStoreRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByManufacturer(string manufacturer);
    }
}