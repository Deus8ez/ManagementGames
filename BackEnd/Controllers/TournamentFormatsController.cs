using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentFormatsController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public TournamentFormatsController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/TournamentFormats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentFormat>>> GetTournamentFormats()
        {
            return await _context.TournamentFormats.ToListAsync();
        }

        // GET: api/TournamentFormats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentFormat>> GetTournamentFormat(int id)
        {
            var tournamentFormat = await _context.TournamentFormats.FindAsync(id);

            if (tournamentFormat == null)
            {
                return NotFound();
            }

            return tournamentFormat;
        }

        // PUT: api/TournamentFormats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentFormat(int id, TournamentFormat tournamentFormat)
        {
            if (id != tournamentFormat.FormatId)
            {
                return BadRequest();
            }

            _context.Entry(tournamentFormat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentFormatExists(id))
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

        // POST: api/TournamentFormats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentFormat>> PostTournamentFormat(TournamentFormat tournamentFormat)
        {
            _context.TournamentFormats.Add(tournamentFormat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentFormat", new { id = tournamentFormat.FormatId }, tournamentFormat);
        }

        // DELETE: api/TournamentFormats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentFormat(int id)
        {
            var tournamentFormat = await _context.TournamentFormats.FindAsync(id);
            if (tournamentFormat == null)
            {
                return NotFound();
            }

            _context.TournamentFormats.Remove(tournamentFormat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentFormatExists(int id)
        {
            return _context.TournamentFormats.Any(e => e.FormatId == id);
        }
    }
}
