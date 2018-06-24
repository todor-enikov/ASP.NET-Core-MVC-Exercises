using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Customer
{
    public class AllCustomersViewModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderType OrderType { get; set; }
    }
}
