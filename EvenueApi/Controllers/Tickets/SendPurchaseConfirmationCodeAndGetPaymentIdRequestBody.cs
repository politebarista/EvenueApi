namespace EvenueApi.Controllers.Tickets
{
    public class SendPurchaseConfirmationCodeAndGetPaymentIdRequestBody
    {
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public string CVV { get; set; }
        public string CardHolderName { get; set; }
        public string EventId { get; set; }
        public string CustomerEmail { get; set; }
    }
}
