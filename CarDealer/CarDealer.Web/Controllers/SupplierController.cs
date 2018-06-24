using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Contracts;
using CarDealer.Web.Models.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [Route("suppliers/{supplierType}")]
        public IActionResult All(string supplierType)
        {
            bool isImporter = supplierType.ToLower() == "importers" ? true : false;

            var allSuppliers = this.supplierService.All(isImporter);

            return View(new AllSuppliersViewModel { IsImporter = isImporter, AllSuppliers = allSuppliers });
        }
    }
}