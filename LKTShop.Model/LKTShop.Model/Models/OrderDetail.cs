using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKTShop.Model.Models
{ 
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Orders { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
    }
}
