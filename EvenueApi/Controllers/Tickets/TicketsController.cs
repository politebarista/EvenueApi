using EvenueApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace EvenueApi.Controllers.Tickets
{
    [Route("ticket")]
    [ApiController]
    public class TicketsController
    {
        readonly private TicketPurchase TicketPurchase = new TicketPurchase(Program.EventsRepository, Program.TicketsRepository, Program.CustomersRepository);

        [Route("sendPurchaseConfirmationCode")]
        [HttpPost]
        public object SendPurchaseConfirmationCode([FromBody] SendPurchaseConfirmationCodeRequestBody body)
        {
            return TicketPurchase.SendPurchaseConfirmationCode(body.CardNumber, body.CardExpirationDate, body.CVV, body.CardHolderName, body.EventId, body.CustomerEmail);
        }
    }
}
