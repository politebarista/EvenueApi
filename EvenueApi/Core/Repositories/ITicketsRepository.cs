using EvenueApi.Core.Models;
using System.Collections.Generic;

namespace EvenueApi.Core.Repositories
{
    internal interface ITicketsRepository
    {
        internal List<Ticket> GetTickets();
        internal bool CreateTicket(Ticket ticket);
    }
}
