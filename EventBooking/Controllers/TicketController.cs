using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExperienceBooking.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketContext _context;

        private readonly ExperienceContext _experienceContext; 

        public TicketController(TicketContext context, ExperienceContext experienceContext)
        {
            _context = context;
            _experienceContext = experienceContext;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> GetAll()
        {
            return _context.Tickets.ToList();
        }

        [HttpGet("{id}", Name = "GetTickets")]
        public ActionResult<Ticket> GetById(long id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            var experience = _experienceContext.Experiences.Find(ticket.ExperienceId);
            ticket.Price = experience.Price; 
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return CreatedAtRoute("GetTickets", new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return NoContent();
        }
    }




}
