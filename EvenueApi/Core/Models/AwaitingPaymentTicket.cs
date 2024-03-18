namespace EvenueApi.Core.Models
{
    internal class AwaitingPaymentTicket
    {
        public string Id { get; }
        public string EventId { get; }
        public string ConfirmationCode { get; }
        public Customer Customer { get; }

        // TODO: add something like DateTime AddingDateTime to track & handle payment that has been in the queue for too long
        internal AwaitingPaymentTicket(string id,  string eventId, string confirmationCode, Customer customer)
        {
            Id = id;
            EventId = eventId;
            ConfirmationCode = confirmationCode;
            Customer = customer;
        }
    }
}
