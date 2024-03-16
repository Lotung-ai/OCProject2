using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        Product[] GetAllProducts();

         void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
