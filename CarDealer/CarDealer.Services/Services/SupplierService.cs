using CarDealer.Data;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealer.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerSystemDbContext dbContext;

        public SupplierService(CarDealerSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<SupplierModel> All(bool isImporter)
            => this.dbContext.Suppliers.AsQueryable()
                   .Where(x => x.IsImporter == isImporter)
                   .Select(s => new SupplierModel
                   {
                       Id = s.Id,
                       Name = s.Name,
                       NumberOfParts = s.Parts.Count()
                   })
                   .ToList();



    }
}
