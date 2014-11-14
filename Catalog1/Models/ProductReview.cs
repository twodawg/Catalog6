using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Catalog1.Models
{
    public class ProductReview
    {
        [Key]
        public int ProductReviewID { get; set; }

        public bool IsApproved { get; set; }

        public string Title { get; set; }

        public string ReviewText { get; set; }

        public int? Rating { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
