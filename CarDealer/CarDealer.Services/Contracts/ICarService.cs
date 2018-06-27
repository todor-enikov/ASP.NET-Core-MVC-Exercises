using CarDealer.Data.Models;
using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarModel> AllCars(string make);

        IEnumerable<CarsWithPartsModel> AllCarsWithParts();

        void Add(Car car);
    }
}
