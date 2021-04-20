using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Data.Context;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistenciasController : ControllerBase
    {
        private readonly MySqlContext _context;

        public AssistenciasController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Assistencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assistencia>>> GetAssistencia()
        {
            return await _context.Assistencia.ToListAsync();
        }

        // GET: api/Assistencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assistencia>> GetAssistencia(int id)
        {
            var assistencia = await _context.Assistencia.FindAsync(id);

            if (assistencia == null)
            {
                return NotFound();
            }

            return assistencia;
        }

        // PUT: api/Assistencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssistencia(int id, Assistencia assistencia)
        {
            if (id != assistencia.assistencia_id)
            {
                return BadRequest();
            }

            _context.Entry(assistencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistenciaExists(id))
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

        // POST: api/Assistencias
        [HttpPost]
        public async Task<ActionResult<Assistencia>> PostAssistencia(Assistencia assistencia)
        {
            _context.Assistencia.Add(assistencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssistencia", new { id = assistencia.assistencia_id }, assistencia);
        }

        // DELETE: api/Assistencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssistencia(int id)
        {
            var assistencia = await _context.Assistencia.FindAsync(id);
            if (assistencia == null)
            {
                return NotFound();
            }

            _context.Assistencia.Remove(assistencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssistenciaExists(int id)
        {
            return _context.Assistencia.Any(e => e.assistencia_id == id);
        }
    }
}
