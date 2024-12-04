using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BackendBurguerMania.Context;
using BackendBurguerMania.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackendBurguerMania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly BurguerManiaContext _context;

        public StatusController(BurguerManiaContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Status/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound(new { message = "Status não encontrado." });
            }

            return status;
        }

        // POST: api/Status
        [HttpPost]
        public async Task<ActionResult<Status>> CreateStatus(Status status)
        {
            if (string.IsNullOrWhiteSpace(status.Name_Status))
            {
                return BadRequest(new { message = "O nome do status é obrigatório." });
            }

            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatus), new { id = status.ID_Status }, status);
        }

        // PUT: api/Status/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, Status updatedStatus)
        {
            if (id != updatedStatus.ID_Status)
            {
                return BadRequest(new { message = "IDs não correspondem." });
            }

            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound(new { message = "Status não encontrado." });
            }

            status.Name_Status = updatedStatus.Name_Status;
            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, new { message = "Erro ao atualizar o status." });
            }

            return NoContent();
        }

        // DELETE: api/Status/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound(new { message = "Status não encontrado." });
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}