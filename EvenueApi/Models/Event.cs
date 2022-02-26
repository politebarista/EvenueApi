using System;

namespace EvenueApi.Models
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

        public Event(DbEvent dbEvent, Organizer organizer, City city)
        {
            Id = dbEvent.Id;
            Name = dbEvent.Name;
            Description = dbEvent.Description;
            ImageUrl = dbEvent.ImageUrl;
            OldPrice = dbEvent.OldPrice;
            Price = dbEvent.Price;
            StartDate = new EventDateTime(dbEvent.StartDate);
            EndDate = new EventDateTime(dbEvent.EndDate);
            Organizer = organizer;
            City = city;
        }

    }
}