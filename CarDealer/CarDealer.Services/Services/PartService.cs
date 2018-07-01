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

        public void Edit(Part part)
        {
            var partToUpdate = this.dbContext.Parts.Find(part.Id);

            partToUpdate.Price = part.Price;
            partToUpdate.Quantity = part.Quantity;

            this.dbContext.Update(partToUpdate);
            this.dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var partToRemove = this.dbContext.Parts.Find(id);

            this.dbContext.Remove(partToRemove);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<PartModel> All(int page = 1, int pageSize = 10)
            => this.dbContext.Parts
                             .OrderByDescending(p => p.Id)
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .Select(p => new PartModel
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Price = p.Price,
                                 Quantity = p.Quantity
                             })
                             .OrderBy(p => p.Name)
                             .ToList();

        public PartModel ById(int id)
            => dbContext.Parts.Where(p => p.Id == id)
                              .Select(p => new PartModel
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Price = p.Price,
                                  Quantity = p.Quantity

                              })
                              .FirstOrDefault();

        public int Total() => this.dbContext.Parts.Count();
    }
}
