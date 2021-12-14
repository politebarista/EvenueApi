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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Organizer Organizer { get; set; }

        public Event(DbEvent dbEvent, Organizer organizer)
        {
            Id = dbEvent.Id;
            Name = dbEvent.Name;
            Description = dbEvent.Description;
            ImageUrl = dbEvent.ImageUrl;
            OldPrice = dbEvent.OldPrice;
            Price = dbEvent.Price;
            StartDate = dbEvent.StartDate;
            EndDate = dbEvent.EndDate;
            Organizer = organizer;
        }
    }
}