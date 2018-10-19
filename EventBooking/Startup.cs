using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ExperienceBooking.Models; 

namespace ExperienceBooking
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("User"));
            services.AddDbContext<ExperienceContext>(opt => opt.UseInMemoryDatabase("Experience"));
            services.AddDbContext<TicketContext>(opt => opt.UseInMemoryDatabase("Ticket"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

       
        public void Configure (IApplicationBuilder app)
        {
            app.UseMvc();
        }
        
        
    }
}
