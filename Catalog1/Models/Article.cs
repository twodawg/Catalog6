using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Catalog1.Models
{
    public class Article
    {
        
        [Key]
        public int ArticleID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}