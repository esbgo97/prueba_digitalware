using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaDB.Models;
using PruebaDB.Utils;

namespace PruebaDB.Repositories.Bill
{
    public class BillRep : IBillRepository
    {

        private AppDbContext _context;
        public BillRep(DbContext context)
        {
            _context = (AppDbContext)context;
        }
        public int AddBillDetails(int idBill, List<bill_detail> detail)
        {
            throw new System.NotImplementedException();
        }

        public int CreateBill(bill bill)
        {
            throw new System.NotImplementedException();
        }

        public List<bill> GetList(bill bill)
        {
            throw new System.NotImplementedException();
        }
    }
}