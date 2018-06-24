using CarDealer.Data;
using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerSystemDbContext dbContext;

        public CustomerService(CarDealerSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<CustomerModel> AllCustomers(OrderType order)
        {
            var customersQuery = this.dbContext.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    customersQuery = this.dbContext.Customers
                                                   .OrderBy(x => x.BirthDate)
                                                   .ThenBy(x => x.IsYoungDriver);
                    break;
                case OrderType.Descending:
                    customersQuery = this.dbContext.Customers
                                                   .OrderByDescending(x => x.BirthDate)
                                                   .ThenByDescending(x => x.IsYoungDriver);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid {order} type!");
            }

            return customersQuery.Select(c => new CustomerModel
            {
                Name = c.Name,
                Birthday = c.BirthDate,
                IsYoungDriver = c.IsYoungDriver
            }).ToList();
        }

        public CustomerByIdModel CustomerById(int id)
            => this.dbContext.Customers.Where(c => c.Id == id)
                                       .Select(c => new CustomerByIdModel
                                       {
                                           Id = id,
                                           Name = c.Name,
                                           BoughtCarsCount = c.Sales.Count(),
                                           TotalSpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Part.Price))
                                       })
                                       .FirstOrDefault();


    }
}
