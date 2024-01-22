using EvenueApi.Core.Models;

namespace EvenueApi.Core.Repositories
{
    internal interface ICustomerRepository
    {
        public bool CreateCustomer(Customer customer);
        public Customer GetCustomer(string email);
        public Customer UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string email);
    }
}
