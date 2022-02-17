using InternetMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Common.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(string customerId);

        Task<string> CreateCustomer(Customer customer);

        Task<bool> IsCustomerExists(string customerId);
    }
}
