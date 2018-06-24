using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Contracts
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> All(bool isImporter);
    }
}
