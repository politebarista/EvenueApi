using EvenueApi.Core.Models;
using EvenueApi.Core.Repositories;
using System;
using System.Collections.Generic;

#nullable enable
namespace EvenueApi.Repositories
{
    internal class LocalDatabaseOrganizerRepository : IOrganizerRepository
    {
        DatabaseContext context = new DatabaseContext();

        bool IOrganizerRepository.CreateOrganizer(Organizer organizer)
        {
            throw new NotImplementedException();
        }

        Organizer? IOrganizerRepository.GetOrganizer(string organizerContactPersonEmail)
        {
            return context.GetOrganizers().Find((Organizer organizer) => organizer.ContactPersonEmail == organizerContactPersonEmail);
        }

        List<Organizer> IOrganizerRepository.GetOrganizers()
        {
            return context.GetOrganizers();
        }

        Organizer IOrganizerRepository.UpdateOrganizer(Organizer organizer)
        {
            throw new NotImplementedException();
        }
    }
}
