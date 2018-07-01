using CarDealer.Data.Models;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<PartModel> All(int page, int pageSize);

        void Add(Part part);

        void Edit(Part part);

        void Delete(int id);

        PartModel ById(int id);

        int Total();
    }
}
