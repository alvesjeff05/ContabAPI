﻿using System;
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
    public class ServicoesController : ControllerBase
    {
        private readonly contabfinContext _context;

        public ServicoesController(contabfinContext context)
        {
            _context = context;
        }

        // GET: api/Servicoes
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
          if (_context.Servicos == null)
          {
              return NotFound();
          }
            return await _context.Servicos.ToListAsync();
        }

        // GET: api/Servicoes/5
        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<Servico>> GetServico(int id)
        {
          if (_context.Servicos == null)
          {
              return NotFound();
          }
            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        // PUT: api/Servicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutServico(int id, Servico servico)
        {
            if (id != servico.IdServico)
            {
                return BadRequest();
            }

            _context.Entry(servico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicoExists(id))
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

        // POST: api/Servicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Servico>> PostServico(Servico servico)
        {
          if (_context.Servicos == null)
          {
              return Problem("Entity set 'contabfinContext.Servicos'  is null.");
          }
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServico", new { id = servico.IdServico }, servico);
        }

        // DELETE: api/Servicoes/5
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteServico(int id)
        {
            if (_context.Servicos == null)
            {
                return NotFound();
            }
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicoExists(int id)
        {
            return (_context.Servicos?.Any(e => e.IdServico == id)).GetValueOrDefault();
        }
    }
}
