namespace EvenueApi.Core.Models
{
    internal class AwaitingPaymentTicket
    {
        public string Id { get; }
        public string EventId { get; }
        public string ConfirmationCode { get; }
        public string CustomerId { get; }

        // TODO: add something like DateTime AddingDateTime to track & handle payment that has been in the queue for too long
        internal AwaitingPaymentTicket(string id,  string eventId, string confirmationCode, string customerId)
        {
            Id = Id;
            EventId = EventId;
            ConfirmationCode = ConfirmationCode;
            CustomerId = customerId;
        }
    }
}
