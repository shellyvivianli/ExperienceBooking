using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExperienceBooking.Models
{
    public class ExperienceContext : DbContext
    {
        public ExperienceContext(DbContextOptions<ExperienceContext> options) : base(options)
        {

        }

        public DbSet<Experience> Experiences { get; set; }

    }
}
