using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Catalog1.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        public virtual ICollection<CartItem> Carts { get; set; }

        public string UserName { get; set; }

        public bool IsFulfilled { get; set; }

        [NotMapped]
        public Decimal PriceTotal
        {
            get
            {
                Decimal total = 0m;

                foreach (CartItem cartItem in Carts)
                {
                    total += cartItem.SubTotal;
                }
                return total;
            }
        }
    }
}