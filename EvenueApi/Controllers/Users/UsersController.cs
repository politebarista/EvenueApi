using EvenueApi.Controllers.Users;
using EvenueApi.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EvenueApi.Controllers
{
    [ApiController]
    public class UsersController
    {
        DatabaseContext context = new DatabaseContext();

        [Route("loginUser")]
        [HttpPost]
        public string LoginUser([FromBody]LoginUserRequestBody body)
        {
            List<User> users = context.GetUsers();

            User? user = users.Find(user => user.Email == body.Email);

            string response;
            if (user != null)
            {
                if (user.Password == body.Password)
                {
                    response = JsonNet.Serialize(user);
                }
                else
                {
                    response = JsonNet.Serialize(StatusCode.IncorrectPassword);
                }

            }
            else
            {
                response = JsonNet.Serialize(StatusCode.UserDontExist);
            }

            return response;
        }

        [Route("registerUser")]
        [HttpPost]
        public string RegisterUser(string id, string lastName, string firstName, string email, string phoneNumber, string password)
        {
            List<User> users = context.GetUsers();

            User? user = users.Find(user => user.Email == email);
            if (user != null)
            {
                return StatusCode.UserAlreadyExist;
            }
            else
            {
                bool userRegistered = context.AddUser(new User(id, lastName, firstName, email, phoneNumber, password));
                if (userRegistered)
                {
                    return id;
                }
                else
                {
                    return StatusCode.ErrorWhileCreatingUser;
                }
            }
        }
    }
}
