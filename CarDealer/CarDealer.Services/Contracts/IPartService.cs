using CarDealer.Data.Models;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Contracts
{
    public interface IPartService
    {
        IEnumerable<PartModel> All();

        void Add(Part part);
    }
}
