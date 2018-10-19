using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExperienceBooking.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExperienceBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly TicketContext _ticketContext;

        public UserController (UserContext context, TicketContext ticketContext)
        {
            _context = context;
            _ticketContext = ticketContext;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUsers")]
        public ActionResult<User> GetById(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            var tickets = _ticketContext.Tickets.ToList(); 
            for (int i=0; i<tickets.Count; i++)
            {
                if(tickets[i].UserId == user.Id)
                {
                    user.Tickets.Add(tickets[i]);
                }
            }
            return user;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("GetUsers", new { id = user.Id }, user); 
        }

        [HttpPost("{userId}/experience/{experienceId}")]
        public IActionResult PurchaseTicket(long userId, long experienceId)
        {
            var user = _context.Users.Find(userId);
            var ticket = new Ticket();
            ticket.ExperienceId = experienceId;
            user.Tickets.Add(ticket);

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent(); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, User inputUser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = inputUser.Name;
            user.Email = inputUser.Email;

            _context.Users.Update(user);
            _context.SaveChanges();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
