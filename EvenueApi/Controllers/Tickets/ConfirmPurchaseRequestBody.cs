namespace EvenueApi.Controllers.Tickets
{
    public class ConfirmPurchaseRequestBody
    {
        public string AwaitingPaymentTicketId { get; set; }
        public string ConfirmationCode {  get; set; }
    }
}
