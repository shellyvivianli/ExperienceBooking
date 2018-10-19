using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperienceBooking.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Ticket> Tickets { get; set; }

        public User()
        {
            Tickets = new List<Ticket>(); 
        }
    }


}
