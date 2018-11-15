using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XmasTreeApplication.Common.Entities;
using XmasTreeApplication.Common.Repositories;

namespace XmasTreeApplication.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly XmasTreeContext _ctx;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(XmasTreeContext ctx, ILogger<ProductRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string treeSize)
        {
            return _ctx.Products.Where(p => p.TreeSize == treeSize).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}