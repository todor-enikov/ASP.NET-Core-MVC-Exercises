using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Contracts;
using CarDealer.Web.Models.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [Route("cars/{make}")]
        public IActionResult All(string make)
        {
            var allCars = this.carService.AllCars(make);

            return View(new AllCarsViewModel { AllCars = allCars, Make = make });
        }

        [Route("cars/parts")]
        public IActionResult AllCarsWithParts()
            => View(this.carService.AllCarsWithParts());

    }
}