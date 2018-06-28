using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Supplier
{
    public class SupplierViewModel
    {
        [MaxLength(100, ErrorMessage = "The name of the supplier should be less than 100 symbols!")]
        [MinLength(5, ErrorMessage = "The name of the supplier should be more than 5 symbols!")]
        [Required(ErrorMessage = "The supplier name is required!")]
        public string Name { get; set; }

        public bool IsImporter { get; set; }
    }
}
