using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> AllCustomers(OrderType order);

        CustomerByIdModel CustomerById(int id);
    }
}
