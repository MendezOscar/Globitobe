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
    public class ItinerarydetailsController : ControllerBase
    {
        private readonly globitodbContext _context;

        public ItinerarydetailsController(globitodbContext context)
        {
            _context = context;
        }

        // GET: api/Itinerarydetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerarydetails>>> GetItinerarydetails()
        {
            return await _context.Itinerarydetails.ToListAsync();
        }

        // GET: api/Itinerarydetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerarydetails>> GetItinerarydetails(int id)
        {
            var itinerarydetails = await _context.Itinerarydetails.FindAsync(id);

            if (itinerarydetails == null)
            {
                return NotFound();
            }

            return itinerarydetails;
        }

        // PUT: api/Itinerarydetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarydetails(int id, Itinerarydetails itinerarydetails)
        {
            if (id != itinerarydetails.Itinerarydetailid)
            {
                return BadRequest();
            }

            _context.Entry(itinerarydetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarydetailsExists(id))
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

        // POST: api/Itinerarydetails
        [HttpPost]
        public async Task<ActionResult<Itinerarydetails>> PostItinerarydetails(Itinerarydetails itinerarydetails)
        {
            _context.Itinerarydetails.Add(itinerarydetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerarydetails", new { id = itinerarydetails.Itinerarydetailid }, itinerarydetails);
        }

        // DELETE: api/Itinerarydetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Itinerarydetails>> DeleteItinerarydetails(int id)
        {
            var itinerarydetails = await _context.Itinerarydetails.FindAsync(id);
            if (itinerarydetails == null)
            {
                return NotFound();
            }

            _context.Itinerarydetails.Remove(itinerarydetails);
            await _context.SaveChangesAsync();

            return itinerarydetails;
        }

        private bool ItinerarydetailsExists(int id)
        {
            return _context.Itinerarydetails.Any(e => e.Itinerarydetailid == id);
        }
    }
}
