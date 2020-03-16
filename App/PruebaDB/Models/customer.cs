using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDB.Models
{
    [Table("customer")]
    public class customer
    {
        public int id { get; set; }
        public string idENTIFICAION { get; set; }
        public string FULLname { get; set; }
        public DateTime BIRTH { get; set; }

    }
}