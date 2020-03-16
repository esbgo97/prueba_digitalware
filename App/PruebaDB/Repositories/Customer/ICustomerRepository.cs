using System.Collections.Generic;
using PruebaDB.Models;

namespace PruebaDB.Repositories.Customer
{
    public interface ICustomerRepository
    {
        int SaveCustomer(customer customer);
        List<customer> GetList();
    }
}