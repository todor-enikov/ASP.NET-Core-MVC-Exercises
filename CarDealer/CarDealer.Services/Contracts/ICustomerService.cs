using CarDealer.Data.Models;
using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> AllCustomers(OrderType order);

        CustomerByIdModel CustomerById(int id);

        EditCustomerByIdModel EditCustomerById(int id);

        void Add(Customer model);

        void Edit(Customer model);
    }
}
