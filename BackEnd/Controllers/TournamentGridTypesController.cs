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
    public class TournamentGridTypesController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public TournamentGridTypesController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/TournamentGridTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentGridType>>> GetTournamentGridTypes()
        {
            return await _context.TournamentGridTypes.ToListAsync();
        }

        // GET: api/TournamentGridTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentGridType>> GetTournamentGridType(int id)
        {
            var tournamentGridType = await _context.TournamentGridTypes.FindAsync(id);

            if (tournamentGridType == null)
            {
                return NotFound();
            }

            return tournamentGridType;
        }

        // PUT: api/TournamentGridTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentGridType(int id, TournamentGridType tournamentGridType)
        {
            if (id != tournamentGridType.GridId)
            {
                return BadRequest();
            }

            _context.Entry(tournamentGridType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentGridTypeExists(id))
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

        // POST: api/TournamentGridTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentGridType>> PostTournamentGridType(TournamentGridType tournamentGridType)
        {
            _context.TournamentGridTypes.Add(tournamentGridType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentGridType", new { id = tournamentGridType.GridId }, tournamentGridType);
        }

        // DELETE: api/TournamentGridTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentGridType(int id)
        {
            var tournamentGridType = await _context.TournamentGridTypes.FindAsync(id);
            if (tournamentGridType == null)
            {
                return NotFound();
            }

            _context.TournamentGridTypes.Remove(tournamentGridType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentGridTypeExists(int id)
        {
            return _context.TournamentGridTypes.Any(e => e.GridId == id);
        }
    }
}
