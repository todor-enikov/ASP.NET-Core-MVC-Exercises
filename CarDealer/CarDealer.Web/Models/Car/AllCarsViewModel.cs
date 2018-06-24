using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Car
{
    public class AllCarsViewModel
    {
        public IEnumerable<CarModel> AllCars { get; set; }

        public string Make { get; set; }
    }
}
