using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDB.Models
{
    [Table("bill_detail")]
    public class bill_detail
    {
        public int id { get; set; }
        public int bill_id { get; set; }
        public int product_id { get; set; }
        public int count { get; set; }
        public float price { get; set; }
    }
}