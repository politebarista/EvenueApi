using System;

namespace EvenueApi.Core.Models
{
    public class Ticket
    {
        public string Id { get; }
        public Event Event { get; }
        public Customer Customer { get; }
        public DateTime PurchaseDate { get; }

        public Ticket(string id, Event Event, Customer customer, DateTime purchaseDate)
        {
            Id = id;
            this.Event = Event;
            Customer = customer;
            PurchaseDate = purchaseDate;
        }
    }
}
