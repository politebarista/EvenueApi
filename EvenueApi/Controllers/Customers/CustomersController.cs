using EvenueApi.Controllers.Customers;
using EvenueApi.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class CustomersController
    {
        DatabaseContext context = new DatabaseContext();

        [Route("loginCustomer")]
        [HttpPost]
        public object LoginCustomer([FromBody]LoginCustomerRequestBody body)
        {
            List<Customer> customers = context.GetCustomers();

            Customer? customer = customers.Find(customer => customer.Email == body.Email);

            object response;
            if (customer != null)
            {
                if (customer.Password == body.Password)
                {
                    response = customer;
                }
                else
                {
                    response = JsonNet.Serialize(EvenueStatusCode.IncorrectPassword);
                }

            }
            else
            {
                response = JsonNet.Serialize(EvenueStatusCode.CustomerDontExist);
            }

            return response;
        }

        [Route("registerCustomer")]
        [HttpPost]
        public string RegisterCustomer(string id, string lastName, string firstName, string email, string phoneNumber, string password)
        {
            List<Customer> customers = context.GetCustomers();

            Customer? customer = customers.Find(customer => customer.Email == email);
            if (customer != null)
            {
                return EvenueStatusCode.CustomerAlreadyExist;
            }
            else
            {
                bool customerRegistered = context.AddCustomer(new Customer(id, lastName, firstName, email, phoneNumber, password));
                if (customerRegistered)
                {
                    return id;
                }
                else
                {
                    return EvenueStatusCode.ErrorWhileCreatingCustomer;
                }
            }
        }
    }
}
