using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Contracts;
using CarDealer.Web.Models.Sale;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("sales")]
    public class SaleController : Controller
    {
        private const int PageSize = 25;

        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [Route("all")]
        public IActionResult All(int page = 1)
        {
            var allSales = this.saleService.All(page, PageSize);

            var allSalesViewModel = new AllSalesViewModel()
            {
                Sales = allSales,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.saleService.TotalSales() / (double)PageSize)
            };

            return View(allSalesViewModel);
        }

        [Route("{id}")]
        public IActionResult ById(int id)
        {
            return View(this.saleService.ById(id));
        }

        [Route("discounted")]
        public IActionResult Discounted()
        {
            return View(this.saleService.Discounted());
        }

        [Route("discounted/{percent}")]
        public IActionResult DiscountedWithPercent(double percent)
        {
            return View(this.saleService.DiscountedWithGivenPercent(percent));
        }
    }
}

   