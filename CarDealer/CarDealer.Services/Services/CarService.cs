using CarDealer.Data;
using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealerSystemDbContext dbContext;

        public CarService(CarDealerSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Car car)
        {
            this.dbContext.Add(car);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<CarModel> AllCars(string make)
        {
            var allCars = this.dbContext.Cars.AsQueryable().Where(x => x.Make.ToLower().Equals(make.ToLower()));
            var allCarsSorted = allCars.OrderBy(x => x.Model).ThenByDescending(x => x.TravelledDistance);

            return allCarsSorted.Select(c => new CarModel
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance
            }).ToList();
        }

        public IEnumerable<CarsWithPartsModel> AllCarsWithParts()
            =>  this.dbContext.Cars
                              .Select(c => new CarsWithPartsModel
                              {
                                  Make = c.Make,
                                  Model = c.Model,
                                  TravelledDistance = c.TravelledDistance,
                                  Parts = c.Parts.Select(p =>
                                    new PartModel
                                    {
                                        Name = p.Part.Name,
                                        Price = p.Part.Price
                                    })
                              })
                              .ToList();

    }
}
