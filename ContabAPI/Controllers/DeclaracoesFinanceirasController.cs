using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContabAPI.Context;
using ContabAPI.Models;

namespace ContabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclaracoesFinanceirasController : ControllerBase
    {
        private readonly contabfinContext _context;

        public DeclaracoesFinanceirasController(contabfinContext context)
        {
            _context = context;
        }

        // GET: api/DeclaracoesFinanceiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeclaracoesFinanceira>>> GetDeclaracoesFinanceiras()
        {
          if (_context.DeclaracoesFinanceiras == null)
          {
              return NotFound();
          }
            return await _context.DeclaracoesFinanceiras.ToListAsync();
        }

        // GET: api/DeclaracoesFinanceiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeclaracoesFinanceira>> GetDeclaracoesFinanceira(int id)
        {
          if (_context.DeclaracoesFinanceiras == null)
          {
              return NotFound();
          }
            var declaracoesFinanceira = await _context.DeclaracoesFinanceiras.FindAsync(id);

            if (declaracoesFinanceira == null)
            {
                return NotFound();
            }

            return declaracoesFinanceira;
        }

        // PUT: api/DeclaracoesFinanceiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeclaracoesFinanceira(int id, DeclaracoesFinanceira declaracoesFinanceira)
        {
            if (id != declaracoesFinanceira.IdDeclaracao)
            {
                return BadRequest();
            }

            _context.Entry(declaracoesFinanceira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeclaracoesFinanceiraExists(id))
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

        // POST: api/DeclaracoesFinanceiras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeclaracoesFinanceira>> PostDeclaracoesFinanceira(DeclaracoesFinanceira declaracoesFinanceira)
        {
          if (_context.DeclaracoesFinanceiras == null)
          {
              return Problem("Entity set 'contabfinContext.DeclaracoesFinanceiras'  is null.");
          }
            _context.DeclaracoesFinanceiras.Add(declaracoesFinanceira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeclaracoesFinanceira", new { id = declaracoesFinanceira.IdDeclaracao }, declaracoesFinanceira);
        }

        // DELETE: api/DeclaracoesFinanceiras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeclaracoesFinanceira(int id)
        {
            if (_context.DeclaracoesFinanceiras == null)
            {
                return NotFound();
            }
            var declaracoesFinanceira = await _context.DeclaracoesFinanceiras.FindAsync(id);
            if (declaracoesFinanceira == null)
            {
                return NotFound();
            }

            _context.DeclaracoesFinanceiras.Remove(declaracoesFinanceira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeclaracoesFinanceiraExists(int id)
        {
            return (_context.DeclaracoesFinanceiras?.Any(e => e.IdDeclaracao == id)).GetValueOrDefault();
        }
    }
}
