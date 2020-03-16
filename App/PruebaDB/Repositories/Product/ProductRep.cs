using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PruebaDB.Models;
using PruebaDB.Utils;

namespace PruebaDB.Repositories.Product
{
    public class ProductRep : IProductRepository
    {
        private AppDbContext _context;
        public ProductRep(DbContext context)
        {
            _context = (AppDbContext)context;
        }
        public bool AddToStock(int id, int total)
        {
            throw new System.NotImplementedException();
        }

        public bool DiscountFromStock(int id, int total)
        {
            throw new System.NotImplementedException();
        }

        public List<product> GetList()
        {
            return _context.Products.ToList();
        }

        public int SaveProduct(product product)
        {
            _context.Add(product);
            return _context.SaveChanges();
        }

        public bool Update(int id, product product)
        {
            throw new System.NotImplementedException();
        }
    }
}