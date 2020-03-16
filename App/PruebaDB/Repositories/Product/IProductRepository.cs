using System.Collections.Generic;
using PruebaDB.Models;

namespace PruebaDB.Repositories.Product
{
    public interface IProductRepository
    {
        int SaveProduct(product product);
        bool Update(int id, product product);
        bool DiscountFromStock(int id, int total);
        bool AddToStock(int id, int total);
        List<product> GetList();
    }
}