using System;
using System.Collections.Generic;
using System.Text;
using XmasTreeApplication.Common.Entities;

namespace XmasTreeApplication.Common.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}
