using CarDealer.Web.Models.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Part
{
    public class AddPartViewModel
    {
        [MaxLength(100, ErrorMessage = "The name should be less than 100 symbols!")]
        [MinLength(5, ErrorMessage = "The name should be more than 5 symbols!")]
        [Required(ErrorMessage = "The name is required!")]
        public string Name { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "The part price couldn't be less than 0!")]
        [Required(ErrorMessage = "The price is required!")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "The supplier is required!")]
        public SupplierViewModel Supplier { get; set; }
    }
}
