using System;
using EvenueApi.Controllers.Customers;
using EvenueApi.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

# nullable enable
namespace EvenueApi.Controllers
{
    [ApiController]
    public class CustomersController
    {
        DatabaseContext context = new DatabaseContext();

        [Route("loginCustomer")]
        [HttpPost]
        public object LoginCustomer([FromBody] LoginCustomerRequestBody body)
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
        public object RegisterCustomer([FromBody] RegisterCustomerRequestBody body)
        {
            List<Customer> customers = context.GetCustomers();

            Customer? customerWithSameEmail = customers.Find(customer => customer.Email == body.Email);
            if (customerWithSameEmail != null)
            {
                return JsonNet.Serialize(EvenueStatusCode.CustomerAlreadyExist);
            }

            string newCustomerUuid = Guid.NewGuid().ToString();
            Customer newCustomer = new Customer(newCustomerUuid, body.LastName, body.FirstName, body.Email, body.PhoneNumber, body.Password, "");
            bool customerRegistered = context.AddCustomer(newCustomer);
            if (customerRegistered)
            {
                return newCustomer;
            }
            else
            {
                return JsonNet.Serialize(EvenueStatusCode.ErrorWhileCreatingCustomer);
            }
        }
    }
}
