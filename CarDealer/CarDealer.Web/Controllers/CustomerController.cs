using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(AddCustomerViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerToAdd = new Customer()
            {
                Name = model.Name,
                BirthDate = model.Birthday,
                IsYoungDriver = model.IsYoungDriver
            };

            this.customerService.Add(customerToAdd);

            return RedirectToAction(nameof(All), new { order = OrderType.Ascending });
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            OrderType orderType = order.ToLower() == "ascending"
                                ? OrderType.Ascending : OrderType.Descending;

            var allCustomers = this.customerService.AllCustomers(orderType);

            return View(new AllCustomersViewModel { Customers = allCustomers, OrderType = orderType });
        }

        [Route("{id}")]
        public IActionResult ById(string id)
        {
            var customerById = this.customerService.CustomerById(int.Parse(id));

            return View(customerById);
        }
    }
}