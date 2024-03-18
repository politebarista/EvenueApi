using EvenueApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace EvenueApi.Controllers.Tickets
{
    [Route("ticket")]
    [ApiController]
    public class TicketsController
    {
        private readonly TicketPurchase TicketPurchase = Program.TicketPurchase;

        [Route("sendPurchaseConfirmationCodeAndGetPaymentId")]
        [HttpPost]
        public object SendPurchaseConfirmationCodeAndGetPaymentId([FromBody] SendPurchaseConfirmationCodeAndGetPaymentIdRequestBody body)
        {
            return TicketPurchase.SendPurchaseConfirmationCodeAndGetPaymentId(body.CardNumber, body.CardExpirationDate, body.CVV, body.CardHolderName, body.EventId, body.CustomerEmail);
        }

        [Route("confirmPurchase")]
        [HttpPost]
        public object ConfirmPurchase([FromBody] ConfirmPurchaseRequestBody body)
        {
            return TicketPurchase.ConfirmPurchase(body.AwaitingPaymentTicketId, body.ConfirmationCode);
        }
    }
}
