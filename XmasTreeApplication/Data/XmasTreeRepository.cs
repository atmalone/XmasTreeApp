using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using XmasTreeApplication.Data.Entities;

namespace XmasTreeApplication.Data
{
    public class XmasTreeRepository : IXmasTreeRepository
    {
        private readonly XmasTreeContext _ctx;
        private readonly ILogger<XmasTreeRepository> _logger;

        public XmasTreeRepository(XmasTreeContext ctx, ILogger<XmasTreeRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void AddEntity(object model)
        {
            throw new System.NotImplementedException();
        }
    }
}