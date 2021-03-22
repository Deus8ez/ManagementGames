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
    public class TournamentTypesController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public TournamentTypesController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/TournamentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentType>>> GetTournamentTypes()
        {
            return await _context.TournamentTypes.ToListAsync();
        }

        // GET: api/TournamentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentType>> GetTournamentType(int id)
        {
            var tournamentType = await _context.TournamentTypes.FindAsync(id);

            if (tournamentType == null)
            {
                return NotFound();
            }

            return tournamentType;
        }

        // PUT: api/TournamentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentType(int id, TournamentType tournamentType)
        {
            if (id != tournamentType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(tournamentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentTypeExists(id))
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

        // POST: api/TournamentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentType>> PostTournamentType(TournamentType tournamentType)
        {
            _context.TournamentTypes.Add(tournamentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentType", new { id = tournamentType.TypeId }, tournamentType);
        }

        // DELETE: api/TournamentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentType(int id)
        {
            var tournamentType = await _context.TournamentTypes.FindAsync(id);
            if (tournamentType == null)
            {
                return NotFound();
            }

            _context.TournamentTypes.Remove(tournamentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentTypeExists(int id)
        {
            return _context.TournamentTypes.Any(e => e.TypeId == id);
        }
    }
}
