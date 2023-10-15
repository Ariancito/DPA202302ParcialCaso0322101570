using DPA202302ParcialCaso0322101570.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Metrics;

namespace DPA202302ParcialCaso0322101570.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerrotoryController : ControllerBase
    {
        private readonly Territory _context;

        public TerrotoryController(Territory context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Territory>>> GetConfiguracion()
        {
          if (_context.territory == null)
          {
              return NotFound();
          }
            return await _context.Territory.ToListAsync();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracion(string id, Territory configuracion)
        {
            if (id != Territory.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(Territory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerritoryExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Territory>> PostConfiguracion(Territory configuracion)
        {
            if (_context.Territory == null)
            {
                return Problem("Entity set 'db03.Configuracion'  is null.");
            }
            _context.Territory.Add(configuracion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TerritoryExists(Territory.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConfiguracion", new { id = Territory.Codigo }, configuracion);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerritory(string id)
        {
            if (_context.Territory == null)
            {
                return NotFound();
            }
            var configuracion = await _context.Territory.FindAsync(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            _context.Territory.Remove(configuracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
