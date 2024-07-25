using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpacexWatchApp.Data;
using SpacexWatchApp.Models;

namespace SpacexWatchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedLaunchesController : ControllerBase
    {
        private readonly LaunchesContext _context;

        public SavedLaunchesController(LaunchesContext context)
        {
            _context = context;
        }

        // GET: api/SavedLaunches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavedLaunches>>> GetSavedLaunches()
        {
          if (_context.SavedLaunches == null)
          {
              return NotFound();
          }
            return await _context.SavedLaunches.ToListAsync();
        }

        // GET: api/SavedLaunches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavedLaunches>> GetSavedLaunches(int id)
        {
          if (_context.SavedLaunches == null)
          {
              return NotFound();
          }
            var savedLaunches = await _context.SavedLaunches.FindAsync(id);

            if (savedLaunches == null)
            {
                return NotFound();
            }

            return savedLaunches;
        }

        // PUT: api/SavedLaunches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavedLaunches(int id, SavedLaunches savedLaunches)
        {
            if (id != savedLaunches.FlightNumber)
            {
                return BadRequest();
            }

            _context.Entry(savedLaunches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedLaunchesExists(id))
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

        // POST: api/SavedLaunches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavedLaunches>> PostSavedLaunches(SavedLaunches savedLaunches)
        {
          if (_context.SavedLaunches == null)
          {
              return Problem("Entity set 'LaunchesContext.SavedLaunches'  is null.");
          }
            _context.SavedLaunches.Add(savedLaunches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavedLaunches", new { id = savedLaunches.FlightNumber }, savedLaunches);
        }

        // DELETE: api/SavedLaunches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedLaunches(int id)
        {
            if (_context.SavedLaunches == null)
            {
                return NotFound();
            }
            var savedLaunches = await _context.SavedLaunches.FindAsync(id);
            if (savedLaunches == null)
            {
                return NotFound();
            }

            _context.SavedLaunches.Remove(savedLaunches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavedLaunchesExists(int id)
        {
            return (_context.SavedLaunches?.Any(e => e.FlightNumber == id)).GetValueOrDefault();
        }
    }
}
