using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Lanches.Data;
using WebApi_Lanches.Models;

namespace WebApi_Lanches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanchesController : ControllerBase
    {
        private readonly LanchesContext _context;

        public LanchesController(LanchesContext context)
        {
            _context = context;
        }

        // GET: api/Lanches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lanches>>> GetLanches()
        {
            return await _context.Lanches.ToListAsync();
        }

        // GET: api/Lanches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lanches>> GetLanches(int id)
        {
            var lanches = await _context.Lanches.FindAsync(id);

            if (lanches == null)
            {
                return NotFound();
            }

            return lanches;
        }

        // PUT: api/Lanches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanches(int id, Lanches lanches)
        {
            if (id != lanches.LancheId)
            {
                return BadRequest();
            }

            _context.Entry(lanches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanchesExists(id))
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

        // POST: api/Lanches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lanches>> PostLanches(Lanches lanches)
        {
            _context.Lanches.Add(lanches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanches", new { id = lanches.LancheId }, lanches);
        }

        // DELETE: api/Lanches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanches(int id)
        {
            var lanches = await _context.Lanches.FindAsync(id);
            if (lanches == null)
            {
                return NotFound();
            }

            _context.Lanches.Remove(lanches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanchesExists(int id)
        {
            return _context.Lanches.Any(e => e.LancheId == id);
        }
    }
}
