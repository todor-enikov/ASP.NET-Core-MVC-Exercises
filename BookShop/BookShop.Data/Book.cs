using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data
{
    public class Book
    {
        public Book()
        {
            this.Categories = new List<CategoryBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 50)]
        public int Copies { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Edition { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public List<CategoryBook> Categories { get; set; }
    }
}
