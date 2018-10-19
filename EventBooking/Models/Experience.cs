using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperienceBooking.Models
{
    public class Experience
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
   
    }
}
