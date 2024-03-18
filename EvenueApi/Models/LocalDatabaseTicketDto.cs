using System;

namespace EvenueApi.Models
{
    public class LocalDatabaseTicketDto
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime PurchaseDate { get; set; }

        public LocalDatabaseTicketDto(string id, string eventId, string customerEmail, DateTime purchaseDate)
        {
            Id = id;
            EventId = eventId;
            CustomerEmail = customerEmail;
            PurchaseDate = purchaseDate;
        }
    }
}
