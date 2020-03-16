using Microsoft.EntityFrameworkCore;
using PruebaDB.Models;

namespace PruebaDB.Utils
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<bill> Bills {get;set;}
        public DbSet<bill_detail> BillDetails {get;set;}
        public DbSet<product> Products {get;set;}
        public DbSet<customer> Customers {get;set;}
    }
}