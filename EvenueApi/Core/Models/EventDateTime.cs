using System;

namespace EvenueApi.Core.Models
{
    public class EventDateTime
    {
        public string DateTime { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Seconds { get; set; }

        public EventDateTime(DateTime date)
        {
            DateTime = date.ToString();
            Date = DateTime.Split(" ")[0];
            string[] splittedDate = Date.Split(".");
            Day = splittedDate[0];
            Month = splittedDate[1];
            Year = splittedDate[2];
            Time = DateTime.Split(" ")[1];
            string[] splittedTime = Time.Split(".");
            Hours = splittedDate[0];
            Minutes = splittedDate[1];
            Seconds = splittedDate[2];
        }
    }
}
