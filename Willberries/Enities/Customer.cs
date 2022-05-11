using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willberries.Enities
{
    [Table("WB_Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Delegate { get; set; }
    }
}
