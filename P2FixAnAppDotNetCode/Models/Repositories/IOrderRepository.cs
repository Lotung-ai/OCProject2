using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
        List<Order> GetAllOrders();
    }
}
