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
    public class JuryInPanelsController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public JuryInPanelsController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/JuryInPanels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JuryInPanel>>> GetJuryInPanels()
        {
            return await _context.JuryInPanels.ToListAsync();
        }

        // GET: api/JuryInPanels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JuryInPanel>> GetJuryInPanel(int id)
        {
            var juryInPanel = await _context.JuryInPanels.FindAsync(id);

            if (juryInPanel == null)
            {
                return NotFound();
            }

            return juryInPanel;
        }

        // PUT: api/JuryInPanels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJuryInPanel(int id, JuryInPanel juryInPanel)
        {
            if (id != juryInPanel.JuryInPanelId)
            {
                return BadRequest();
            }

            _context.Entry(juryInPanel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuryInPanelExists(id))
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

        // POST: api/JuryInPanels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JuryInPanel>> PostJuryInPanel(JuryInPanel juryInPanel)
        {
            _context.JuryInPanels.Add(juryInPanel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJuryInPanel", new { id = juryInPanel.JuryInPanelId }, juryInPanel);
        }

        // DELETE: api/JuryInPanels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuryInPanel(int id)
        {
            var juryInPanel = await _context.JuryInPanels.FindAsync(id);
            if (juryInPanel == null)
            {
                return NotFound();
            }

            _context.JuryInPanels.Remove(juryInPanel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JuryInPanelExists(int id)
        {
            return _context.JuryInPanels.Any(e => e.JuryInPanelId == id);
        }
    }
}
