using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willberries.Enities
{
    [Table("WB_Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
