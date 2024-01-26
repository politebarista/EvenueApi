using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenueApi.Core
{
    internal class TicketPurchase
    {
        private readonly List<AwaitingPaymentTicket> TicketsAwaitingPayment = new();

        private readonly IEventsRepository EventsRepository;
        private readonly ITicketsRepository TicketsRepository;
        private readonly ICustomerRepository CustomerRepository;

        internal TicketPurchase(IEventsRepository eventsRepository, ITicketsRepository ticketsRepository, ICustomerRepository customerRepository)
        {
            EventsRepository = eventsRepository;
            TicketsRepository = ticketsRepository;
            CustomerRepository = customerRepository;
        }


        // TODO: Add error handling
        // TODO: Move customer card data into separate class
        // First method to call when buying a ticket. Returns the ID of the pending payment, which is needed to confirm the payment in the <paramref name="ConfirmPurchase"/> method.
        internal string SendPurchaseConfirmationCode(string cardNumber, string cardExpirationDate, string CVV, string cardHolderName, string eventId, string customerId)
        {
            //
            // Handling card information data & communication with bank
            //
            string confirmationCode = "111111";

            string awaitingPaymentTicketId = Guid.NewGuid().ToString();
            TicketsAwaitingPayment.Add(new AwaitingPaymentTicket(awaitingPaymentTicketId, eventId, confirmationCode, customerId));

            return awaitingPaymentTicketId;
        }

        internal string ConfirmPurchase(string AwaitingPaymentTicketId, string ConfirmationCode)
        {
            AwaitingPaymentTicket awaitingPaymentTicket = TicketsAwaitingPayment.Find((ticket) => ticket.Id == AwaitingPaymentTicketId);
            if (awaitingPaymentTicket == null)
            {
                return EvenueStatusCode.NoAwaitingPaymentTicket;
            }
            
            if (awaitingPaymentTicket.ConfirmationCode != ConfirmationCode)
            {
                return EvenueStatusCode.IncorrectConfirmationPurchaseCode;
            }

            Event currentEvent = EventsRepository.GetEvent(awaitingPaymentTicket.EventId);
            List<Ticket> ticketsToCurrentEvent = TicketsRepository.GetTickets().Where((ticket) => ticket.Event.Id == awaitingPaymentTicket.EventId).ToList();
            if (ticketsToCurrentEvent.Count == currentEvent.ParticipantsMaxNumber)
            {
                return EvenueStatusCode.NoTicketsLeftForEvent;
            }

            Customer customer = CustomerRepository.GetCustomer(awaitingPaymentTicket.CustomerId);
            Ticket ticket = new(Guid.NewGuid().ToString(), currentEvent, customer, DateTime.Now);
            bool isTickedCreatSuccessfully = TicketsRepository.CreateTicket(ticket: ticket);

            return null;
        }
    }
}
