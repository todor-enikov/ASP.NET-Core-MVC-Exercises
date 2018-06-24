using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Supplier
{
    public class AllSuppliersViewModel
    {
        public bool IsImporter { get; set; }

        public IEnumerable<SupplierModel> AllSuppliers { get; set; }
    }
}
