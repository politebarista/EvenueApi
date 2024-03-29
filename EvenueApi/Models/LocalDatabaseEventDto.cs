﻿using System;

namespace EvenueApi.Models
{
    public class LocalDatabaseEventDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double OldPrice { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organizer { get; set; }
        public string City { get; set; }
        public int ParticipantsMaxNumber { get; set; }
    }
}
