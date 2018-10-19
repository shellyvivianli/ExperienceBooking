using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperienceBooking.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public long ExperienceId { get; set; }
        public long UserId { get; set; }
        public double Price { get; set; }
    }
}
