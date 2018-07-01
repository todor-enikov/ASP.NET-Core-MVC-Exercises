using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("sales")]
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [Route("all")]
        public IActionResult All(int id)
        {
            return View(this.saleService.All());
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