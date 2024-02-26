using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContabAPI.Context;
using ContabAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesFinanceirasController : ControllerBase
    {
        private readonly contabfinContext _context;

        public TransacoesFinanceirasController(contabfinContext context)
        {
            _context = context;
        }

        // GET: api/TransacoesFinanceiras
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<TransacoesFinanceira>>> GetTransacoesFinanceiras()
        {
          if (_context.TransacoesFinanceiras == null)
          {
              return NotFound();
          }
            return await _context.TransacoesFinanceiras.ToListAsync();
        }

        // GET: api/TransacoesFinanceiras/5
        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<TransacoesFinanceira>> GetTransacoesFinanceira(int id)
        {
          if (_context.TransacoesFinanceiras == null)
          {
              return NotFound();
          }
            var transacoesFinanceira = await _context.TransacoesFinanceiras.FindAsync(id);

            if (transacoesFinanceira == null)
            {
                return NotFound();
            }

            return transacoesFinanceira;
        }

        // PUT: api/TransacoesFinanceiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutTransacoesFinanceira(int id, TransacoesFinanceira transacoesFinanceira)
        {
            if (id != transacoesFinanceira.IdTransacao)
            {
                return BadRequest();
            }

            _context.Entry(transacoesFinanceira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacoesFinanceiraExists(id))
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

        // POST: api/TransacoesFinanceiras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<TransacoesFinanceira>> PostTransacoesFinanceira(TransacoesFinanceira transacoesFinanceira)
        {
          if (_context.TransacoesFinanceiras == null)
          {
              return Problem("Entity set 'contabfinContext.TransacoesFinanceiras'  is null.");
          }
            _context.TransacoesFinanceiras.Add(transacoesFinanceira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacoesFinanceira", new { id = transacoesFinanceira.IdTransacao }, transacoesFinanceira);
        }

        // DELETE: api/TransacoesFinanceiras/5
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteTransacoesFinanceira(int id)
        {
            if (_context.TransacoesFinanceiras == null)
            {
                return NotFound();
            }
            var transacoesFinanceira = await _context.TransacoesFinanceiras.FindAsync(id);
            if (transacoesFinanceira == null)
            {
                return NotFound();
            }

            _context.TransacoesFinanceiras.Remove(transacoesFinanceira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacoesFinanceiraExists(int id)
        {
            return (_context.TransacoesFinanceiras?.Any(e => e.IdTransacao == id)).GetValueOrDefault();
        }
    }
}
