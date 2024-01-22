using System;

namespace EvenueApi.Core.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double OldPrice { get; set; }
        public double Price { get; set; }
        public EventDateTime StartDate { get; set; }
        public EventDateTime EndDate { get; set; }
        public Organizer Organizer { get; set; }
        public City City { get; set; }

        public Event(string id, string name, string description, string imageUrl, double oldPrice, double price, DateTime startDateTime, DateTime endDateTime, Organizer organizer, City city)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            OldPrice = oldPrice;
            Price = price;
            StartDate = new EventDateTime(startDateTime);
            EndDate = new EventDateTime(endDateTime);
            Organizer = organizer;
            City = city;
        }
    }
}
