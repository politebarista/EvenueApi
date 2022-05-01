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
        public string LoginCustomer([FromBody]LoginCustomerRequestBody body)
        {
            List<Customer> customers = context.GetCustomers();

            Customer? customer = customers.Find(customer => customer.Email == body.Email);

            string response;
            if (customer != null)
            {
                if (customer.Password == body.Password)
                {
                    response = JsonNet.Serialize(customer);
                }
                else
                {
                    response = JsonNet.Serialize(StatusCode.IncorrectPassword);
                }

            }
            else
            {
                response = JsonNet.Serialize(StatusCode.CustomerDontExist);
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
                return StatusCode.CustomerAlreadyExist;
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
                    return StatusCode.ErrorWhileCreatingCustomer;
                }
            }
        }
    }
}
