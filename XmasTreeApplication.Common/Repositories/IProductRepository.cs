using System;
using System.Collections.Generic;
using XmasTreeApplication.Common.Entities;

namespace XmasTreeApplication.Common.Repositories
{
    public interface IProductRepository : IDisposable 
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        bool SaveAll();
        void AddEntity(object model);
    }
}