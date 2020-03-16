using System.Collections.Generic;
using PruebaDB.Models;

namespace PruebaDB.Repositories.Bill
{
    public interface IBillRepository
    {
        int CreateBill(bill bill);
        int AddBillDetails(int idBill, List<bill_detail> detail);
        List<bill> GetList(bill bill);
    }
}