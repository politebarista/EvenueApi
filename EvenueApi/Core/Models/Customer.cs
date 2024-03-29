﻿namespace EvenueApi.Core.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FavoritesOrganizers { get; set; }

        public Customer(string id, string lastName, string firstName, string email, string phoneNumber, string password, string favoritesOrganizers)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            FavoritesOrganizers = favoritesOrganizers;
        }
    }
}
