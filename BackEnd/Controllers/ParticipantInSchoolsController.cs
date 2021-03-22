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
    public class ParticipantInSchoolsController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public ParticipantInSchoolsController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/ParticipantInSchools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantInSchool>>> GetParticipantInSchools()
        {
            return await _context.ParticipantInSchools.ToListAsync();
        }

        // GET: api/ParticipantInSchools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantInSchool>> GetParticipantInSchool(int id)
        {
            var participantInSchool = await _context.ParticipantInSchools.FindAsync(id);

            if (participantInSchool == null)
            {
                return NotFound();
            }

            return participantInSchool;
        }

        // PUT: api/ParticipantInSchools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantInSchool(int id, ParticipantInSchool participantInSchool)
        {
            if (id != participantInSchool.SchoolParticipantId)
            {
                return BadRequest();
            }

            _context.Entry(participantInSchool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantInSchoolExists(id))
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

        // POST: api/ParticipantInSchools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParticipantInSchool>> PostParticipantInSchool(ParticipantInSchool participantInSchool)
        {
            _context.ParticipantInSchools.Add(participantInSchool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantInSchool", new { id = participantInSchool.SchoolParticipantId }, participantInSchool);
        }

        // DELETE: api/ParticipantInSchools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantInSchool(int id)
        {
            var participantInSchool = await _context.ParticipantInSchools.FindAsync(id);
            if (participantInSchool == null)
            {
                return NotFound();
            }

            _context.ParticipantInSchools.Remove(participantInSchool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantInSchoolExists(int id)
        {
            return _context.ParticipantInSchools.Any(e => e.SchoolParticipantId == id);
        }
    }
}
