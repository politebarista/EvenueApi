using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using EvenueApi.Models;
using System;
using System.Collections.Generic;

namespace EvenueApi.Repositories
{
    internal class LocalDatabaseTicketsRepository : ITicketsRepository
    {
        private readonly DatabaseContext Context;
        private readonly IEventsRepository EventsRepository;
        private readonly ICustomerRepository CustomerRepository;

        LocalDatabaseTicketsRepository(IEventsRepository eventsRepository, ICustomerRepository customerRepository)
        {
            Context = new DatabaseContext();
            EventsRepository = eventsRepository;
            CustomerRepository = customerRepository;
        }

        bool ITicketsRepository.CreateTicket(Ticket ticket)
        {
            LocalDatabaseTicketDto ticketDto = new(Guid.NewGuid().ToString(), ticket.Event.Id, ticket.Customer.Email, ticket.PurchaseDate);
            return Context.AddTicket(ticketDto);
        }

        List<Ticket> ITicketsRepository.GetTickets()
        {
            List<LocalDatabaseTicketDto> dtoTickets = Context.GetTickets();

            List<Ticket> tickets = new();

            for (int i = 0; i < dtoTickets.Count; i++)
            {
                Customer customer = CustomerRepository.GetCustomer(dtoTickets[i].CustomerEmail);
                Event Event = EventsRepository.GetEvent(dtoTickets[i].EventId);

                Ticket ticket = new(dtoTickets[i].Id, Event, customer, dtoTickets[i].PurchaseDate);

                tickets.Add(ticket);
            }

            return tickets;
        }
    }
}
