using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealer.Services.Services
{
    public class SaleService : ISaleService
    {
        private readonly CarDealerSystemDbContext dbContext;

        public SaleService(CarDealerSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<SaleModel> All()
            => this.dbContext.Sales.AsQueryable()
                                   .Select(s => new SaleModel
                                   {
                                       Id = s.Id,
                                       CarId = s.Car_Id,
                                       CustomerId = s.Customer_Id,
                                       Discount = s.Discount
                                   })
                                   .ToList();

        public SaleWithCarAndCustomerModel ById(int id)
        {
            return this.dbContext.Sales.Where(s => s.Id == id)
                                       .Select(s => new SaleWithCarAndCustomerModel
                                       {
                                           Car = new CarModel
                                           {
                                               Make = s.Car.Make,
                                               Model = s.Car.Model,
                                               TravelledDistance = s.Car.TravelledDistance
                                           },
                                           CustomerName = s.Customer.Name,
                                           Discount = s.Discount,
                                           PriceOfSale = s.Car.Parts.Sum(p => p.Part.Price)

                                       })
                                       .FirstOrDefault();
        }

        public IEnumerable<SaleModel> Discounted()
            => this.dbContext.Sales.Where(s => s.Discount != 0)
                                   .Select(s => new SaleModel
                                   {
                                       Id = s.Id,
                                       CarId = s.Car_Id,
                                       CustomerId = s.Customer_Id,
                                       Discount = s.Discount
                                   })
                                   .ToList();

        public IEnumerable<SaleModel> DiscountedWithGivenPercent(double percent)
            => this.dbContext.Sales.Where(s => s.Discount.Equals(percent))
                                   .Select(s => new SaleModel
                                   {
                                       Id = s.Id,
                                       CarId = s.Car_Id,
                                       CustomerId = s.Customer_Id,
                                       Discount = s.Discount
                                   })
                                   .ToList();
    }
}
