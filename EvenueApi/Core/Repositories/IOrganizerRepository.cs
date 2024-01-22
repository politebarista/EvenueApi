using EvenueApi.Core.Models;
using System.Collections.Generic;

namespace EvenueApi.Core.Repositories
{
    internal interface IOrganizerRepository
    {
        internal bool CreateOrganizer(Organizer organizer);
        internal Organizer GetOrganizer(string organizerContactPersonEmail);
        internal List<Organizer> GetOrganizers();
        internal Organizer UpdateOrganizer(Organizer organizer);
    }
}
