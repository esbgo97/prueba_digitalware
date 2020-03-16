using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDB.Models
{
    [Table("product")]
    public class product
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int units { get; set; }
        public float price { get; set; }
    }
}