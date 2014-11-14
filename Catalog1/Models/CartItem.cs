using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Catalog1.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }

        [NotMapped]
        public Decimal SubTotal
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
