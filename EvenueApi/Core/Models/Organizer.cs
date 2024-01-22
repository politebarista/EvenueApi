using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenueApi.Core.Models
{
    public class Organizer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Inn { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonEmail { get; set; }
        public string Password { get; set; }
    }
}
