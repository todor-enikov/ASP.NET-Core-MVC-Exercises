using CarDealer.Data;
using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealer.Services.Services
{
    public class PartService : IPartService
    {
        private readonly CarDealerSystemDbContext dbContext;

        public PartService(CarDealerSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Part part)
        {
            this.dbContext.Add(part);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<PartModel> All()
            => this.dbContext.Parts
                             .Select(p => new PartModel
                             {
                                 Name = p.Name,
                                 Price = p.Price,
                                 Quantity = p.Quantity
                             })
                             .ToList();

    }
}
