using System;

namespace EvenueApi.Models
{
    public class LocalDatabaseTicketDto
    {
        public string Id { get; }
        public string EventId { get; }
        public string CustomerEmail { get; }
        public DateTime PurchaseDate { get; }

        public LocalDatabaseTicketDto(string id, string eventId, string customerEmail, DateTime purchaseDate)
        {
            Id = id;
            EventId = eventId;
            CustomerEmail = customerEmail;
            PurchaseDate = purchaseDate;
        }
    }
}
