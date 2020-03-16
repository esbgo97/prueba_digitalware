using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDB.Models
{
    [Table("bill")]
    public class bill
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime SOLD { get; set; }
        public int customer_id { get; set; }
        public float TOTAL_price { get; set; }

    }
}