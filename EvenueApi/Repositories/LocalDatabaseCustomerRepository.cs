using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using System;
using System.Collections.Generic;

#nullable enable
namespace EvenueApi.Repositories
{
    internal class LocalDatabaseCustomerRepository : ICustomerRepository
    {
        DatabaseContext context = new DatabaseContext();
        bool ICustomerRepository.CreateCustomer(Customer customer)
        {
            bool customerRegistered = context.AddCustomer(customer);

            return customerRegistered;
        }

        bool ICustomerRepository.DeleteCustomer(string email)
        {
            throw new NotImplementedException();
        }
        
        Customer? ICustomerRepository.GetCustomer(string email)
        {
            if (email == null) return null;

            List<Customer> customers = context.GetCustomers();

            Customer? customer = customers.Find(customer => customer.Email == email);

            return customer;
        }

        Customer ICustomerRepository.UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
