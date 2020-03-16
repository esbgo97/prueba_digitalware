using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaDB.Models;
using PruebaDB.Utils;

namespace PruebaDB.Repositories.Customer
{
    public class CustomerRep : ICustomerRepository
    {
        private AppDbContext _context;
        public CustomerRep(DbContext context)
        {
            _context = (AppDbContext)context;
        }
        public List<customer> GetList()
        {
            throw new System.NotImplementedException();
        }

        public int SaveCustomer(customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}