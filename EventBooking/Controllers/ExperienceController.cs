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
    public class ExperienceController : ControllerBase
    {
        private readonly ExperienceContext _context;

        public ExperienceController(ExperienceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Experience>> GetAll()
        {
            return _context.Experiences.ToList();
        }

        [HttpGet("{id}", Name = "GetExperiences")]
        public ActionResult<Experience> GetById(long id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            return experience;
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();

            return CreatedAtRoute("GetExperiences", new { id = experience.Id }, experience);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Experience inputExperience)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null)
            {
                return NotFound();
            }

            experience.Name = inputExperience.Name;
            experience.Date = inputExperience.Date;
            experience.Type = inputExperience.Type;
            experience.Description = inputExperience.Description;

            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return NoContent();
        }
    }




   
}
