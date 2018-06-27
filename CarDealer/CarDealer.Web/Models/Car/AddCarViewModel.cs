using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Car
{
    public class AddCarViewModel
    {

        [MinLength(2, ErrorMessage = "The range of the make shouldn't be less than 2 symbols!")]
        [MaxLength(20, ErrorMessage = "The range of the make shouldn't be more than 20 symbols!")]
        [Required(ErrorMessage = "The make is required!")]
        public string Make { get; set; }

        [MinLength(1, ErrorMessage = "The range of the model shouldn't be less than 1 symbols!")]
        [MaxLength(20, ErrorMessage = "The range of the model shouldn't be more than 20 symbols!")]
        [Required(ErrorMessage = "The model is required!")]
        public string Model { get; set; }

        //[Range(0, ErrorMessage = "The range of the travelled distance could not be less than 0!")]
        [Required(ErrorMessage = "The travelled distance is required!")]
        [Display(Name = "Travelled Distance")]
        public long TravelledDistance { get; set; }
    }
}
