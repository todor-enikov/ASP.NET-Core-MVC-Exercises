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
        private const int PageSize = 25;

        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [Route("add")]
        public IActionResult Add()
            => View();

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
            var allCars = this.carService.AllCarsByMake(make);

            return View(new AllCarsByMakeViewModel { AllCars = allCars, Make = make });
        }

        [Route("parts")]
        public IActionResult AllCarsWithParts(int page = 1)
        {
            var allCarsWithParts = this.carService.AllCarsWithParts(page, PageSize);

            var allCarsWithPartsViewModel = new AllCarsWithPartsViewModel()
            {
                Cars = allCarsWithParts,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.carService.TotalCars() / (double)PageSize)
            };

            return View(allCarsWithPartsViewModel);
        }

    }
}