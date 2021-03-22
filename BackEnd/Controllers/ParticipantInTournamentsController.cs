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
    public class ParticipantInTournamentsController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public ParticipantInTournamentsController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/ParticipantInTournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantInTournament>>> GetParticipantInTournaments()
        {
            return await _context.ParticipantInTournaments.ToListAsync();
        }

        // GET: api/ParticipantInTournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantInTournament>> GetParticipantInTournament(int id)
        {
            var participantInTournament = await _context.ParticipantInTournaments.FindAsync(id);

            if (participantInTournament == null)
            {
                return NotFound();
            }

            return participantInTournament;
        }

        // GET: api/ParticipantInTournaments/getById/5
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipantsInTournament(int id)
        {
            var participantsInTournament = await (from pt in _context.ParticipantInTournaments
                                             join p in _context.Participants on pt.ParticipantInTournamentId equals p.ParticipantId
                                             join r in _context.Roles on pt.ParticpantRoleId equals r.RoleId
                                             where pt.TournamentWithParticipantId == id
                                             select new Participant
                                             {
                                                 ParticipantId = p.ParticipantId,
                                                 Name = p.Name,
                                                 Surname = p.Surname,
                                                 Patronym = p.Patronym,
                                                 BlitzGameRank = p.BlitzGameRank,
                                                 ClassicGameRank = p.ClassicGameRank,
                                                 DateOfBirth = p.DateOfBirth,
                                                 RoleName = r.Role1
                                             }).ToListAsync();

            if (participantsInTournament == null)
            {
                return NotFound();
            }

            return participantsInTournament;
        }

        // PUT: api/ParticipantInTournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantInTournament(int id, ParticipantInTournament participantInTournament)
        {
            if (id != participantInTournament.TournamentWithParticipantId)
            {
                return BadRequest();
            }

            _context.Entry(participantInTournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantInTournamentExists(id))
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

        // POST: api/ParticipantInTournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParticipantInTournament>> PostParticipantInTournament(ParticipantInTournament participantInTournament)
        {
            _context.ParticipantInTournaments.Add(participantInTournament);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipantInTournamentExists(participantInTournament.TournamentWithParticipantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParticipantInTournament", new { id = participantInTournament.TournamentWithParticipantId }, participantInTournament);
        }

        // DELETE: api/ParticipantInTournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantInTournament(int id)
        {
            var participantInTournament = await _context.ParticipantInTournaments.FindAsync(id);
            if (participantInTournament == null)
            {
                return NotFound();
            }

            _context.ParticipantInTournaments.Remove(participantInTournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantInTournamentExists(int id)
        {
            return _context.ParticipantInTournaments.Any(e => e.TournamentWithParticipantId == id);
        }
    }
}
