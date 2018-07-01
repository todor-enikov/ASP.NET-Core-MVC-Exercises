using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Web.Models.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("cars")]
    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(AddCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var carToAdd = new Car()
            {
                Make = viewModel.Make,
                Model = viewModel.Model,
                TravelledDistance = viewModel.TravelledDistance,
                Parts = new List<PartCar>(),
                Sales = new List<Sale>()
            };

            this.carService.Add(carToAdd);

            return View(nameof(AllCarsWithParts));
        }

        [Route("{make}")]
        public IActionResult All(string make)
        {
            var allCars = this.carService.AllCars(make);

            return View(new AllCarsViewModel { AllCars = allCars, Make = make });
        }

        [Route("parts")]
        public IActionResult AllCarsWithParts()
            => View(this.carService.AllCarsWithParts());

    }
}