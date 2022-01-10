using EvenueApi.Models;
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
        public string LoginUser(string email, string password)
        {
            List<User> users = context.GetUsers();

            User? user = users.Find(user => user.Email == email);

            if (user != null)
            {
                if (user.Password == password)
                {
                    return user.Id;
                }
                else
                {
                    return StatusCode.IncorrectPassword;
                }
                
            } 
            else
            {
                return StatusCode.UserDontExist;
            }
        }
    }
}
