using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The name should be less than 100 symbols!")]
        [MinLength(5, ErrorMessage = "The name should be more than 5 symbols!")]
        [Required(ErrorMessage = "The name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The birthday is required!")]
        [DataType(DataType.DateTime, ErrorMessage = "The date time format isn't correct!")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "The is young driver checkbox is required!")]
        [Display(Name = "Is young driver")]
        public bool IsYoungDriver { get; set; }
    }
}
