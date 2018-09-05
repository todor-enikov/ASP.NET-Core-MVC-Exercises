using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Category
    {
        public Category()
        {
            this.Books = new List<CategoryBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public List<CategoryBook> Books { get; set; }
    }
}
