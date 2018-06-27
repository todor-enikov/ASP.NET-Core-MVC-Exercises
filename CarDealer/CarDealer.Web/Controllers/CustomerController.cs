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
        public IActionResult Add(CustomerViewModel model)
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

        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var customerById = this.customerService.EditCustomerById(id);

            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                Name = customerById.Name,
                Birthday = customerById.Birthday,
                IsYoungDriver = customerById.IsYoungDriver
            };

            return View(customerViewModel);
        }

        [Route("edit/{id}")]
        [HttpPost]
        public IActionResult Edit(CustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Customer updateCustomer = new Customer()
            {
                Id=viewModel.Id,
                Name = viewModel.Name,
                BirthDate = viewModel.Birthday,
                IsYoungDriver = viewModel.IsYoungDriver
            };

            this.customerService.Edit(updateCustomer);

            return View(nameof(ById), new { id = viewModel.Id });
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
        public IActionResult ById(int id)
        {
            var customerById = this.customerService.CustomerById(id);

            return View(customerById);
        }
    }
}