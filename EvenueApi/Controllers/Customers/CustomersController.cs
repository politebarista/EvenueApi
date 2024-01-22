using System;
using EvenueApi.Controllers.Customers;
using Json.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;

# nullable enable
namespace EvenueApi.Controllers
{
    [ApiController]
    public class CustomersController
    {
        [Route("loginCustomer")]
        [HttpPost]
        public object LoginCustomer([FromBody] LoginCustomerRequestBody body)
        {
            Customer? customer = Program.CustomersRepository.GetCustomer(body.Email);

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
            ref ICustomerRepository customerRepository = ref Program.CustomersRepository;

            Customer? customerWithSameEmail = customerRepository.GetCustomer(body.Email);
            if (customerWithSameEmail != null)
            {
                return JsonNet.Serialize(EvenueStatusCode.CustomerAlreadyExist);
            }

            // TODO: I think it can be deleted since the email is a Primary Key in the database
            string newCustomerUuid = Guid.NewGuid().ToString();
            Customer newCustomer = new Customer(newCustomerUuid, body.LastName, body.FirstName, body.Email, body.PhoneNumber, body.Password, "");
            bool customerRegistered = customerRepository.CreateCustomer(newCustomer);
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
