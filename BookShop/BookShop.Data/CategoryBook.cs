using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data
{
    public class CategoryBook
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
