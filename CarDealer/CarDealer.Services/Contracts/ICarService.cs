using CarDealer.Data.Models;
using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarModel> AllCarsByMake(string make);

        IEnumerable<CarsWithPartsModel> AllCarsWithParts(int page, int pageSize);

        void Add(Car car);

        int TotalCars();
    }
}
