using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using globitobe.Models;

namespace globitobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly globitodbContext _context;

        public ItineraryController(globitodbContext context)
        {
            _context = context;
        }

        // GET: api/Itinerary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerary>>> GetItinerary()
        {
            return await _context.Itinerary.ToListAsync();
        }

        // GET: api/Itinerary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerary>> GetItinerary(int id)
        {
            var itinerary = await _context.Itinerary.FindAsync(id);

            if (itinerary == null)
            {
                return NotFound();
            }

            return itinerary;
        }

        // PUT: api/Itinerary/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerary(int id, Itinerary itinerary)
        {
            if (id != itinerary.Itineraryid)
            {
                return BadRequest();
            }

            _context.Entry(itinerary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItineraryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Itinerary
        [HttpPost]
        public async Task<ActionResult<Itinerary>> PostItinerary(Itinerary itinerary)
        {
            _context.Itinerary.Add(itinerary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerary", new { id = itinerary.Itineraryid }, itinerary);
        }

        // DELETE: api/Itinerary/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Itinerary>> DeleteItinerary(int id)
        {
            var itinerary = await _context.Itinerary.FindAsync(id);
            if (itinerary == null)
            {
                return NotFound();
            }

            _context.Itinerary.Remove(itinerary);
            await _context.SaveChangesAsync();

            return itinerary;
        }

        private bool ItineraryExists(int id)
        {
            return _context.Itinerary.Any(e => e.Itineraryid == id);
        }
    }
}
