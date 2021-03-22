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
    public class JuryPanelsController : ControllerBase
    {
        private readonly ManagementGamesDB _context;

        public JuryPanelsController(ManagementGamesDB context)
        {
            _context = context;
        }

        // GET: api/JuryPanels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JuryPanel>>> GetJuryPanels()
        {
            return await _context.JuryPanels.ToListAsync();
        }

        // GET: api/JuryPanels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JuryPanel>> GetJuryPanel(int id)
        {
            var juryPanel = await _context.JuryPanels.FindAsync(id);

            if (juryPanel == null)
            {
                return NotFound();
            }

            return juryPanel;
        }

        // PUT: api/JuryPanels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJuryPanel(int id, JuryPanel juryPanel)
        {
            if (id != juryPanel.PanelId)
            {
                return BadRequest();
            }

            _context.Entry(juryPanel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuryPanelExists(id))
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

        // POST: api/JuryPanels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JuryPanel>> PostJuryPanel(JuryPanel juryPanel)
        {
            _context.JuryPanels.Add(juryPanel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJuryPanel", new { id = juryPanel.PanelId }, juryPanel);
        }

        // DELETE: api/JuryPanels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuryPanel(int id)
        {
            var juryPanel = await _context.JuryPanels.FindAsync(id);
            if (juryPanel == null)
            {
                return NotFound();
            }

            _context.JuryPanels.Remove(juryPanel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JuryPanelExists(int id)
        {
            return _context.JuryPanels.Any(e => e.PanelId == id);
        }
    }
}
