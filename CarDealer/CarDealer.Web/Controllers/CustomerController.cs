using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route("customers/all/{order}")]
        public IActionResult All(string order)
        {
            OrderType orderType = order.ToLower() == "ascending"
                                ? OrderType.Ascending : OrderType.Descending;

            var allCustomers = this.customerService.AllCustomers(orderType);

            return View(new AllCustomersViewModel { Customers = allCustomers, OrderType = orderType });
        }

        [Route("customers/{id}")]
        public IActionResult ById(string id)
        {
            var customerById = this.customerService.CustomerById(int.Parse(id));

            return View(customerById);
        }
    }
}