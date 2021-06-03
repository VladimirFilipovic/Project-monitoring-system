using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;

namespace ITSolutionsCompanyV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Documentations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documentation>>> GetDocumentation()
        {
            return await _context.Documentation.ToListAsync();
        }

        // GET: api/Documentations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documentation>> GetDocumentation(Guid id)
        {
            var documentation = await _context.Documentation.FindAsync(id);

            if (documentation == null)
            {
                return NotFound();
            }

            return documentation;
        }

        // PUT: api/Documentations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentation(Guid id, Documentation documentation)
        {
            if (id != documentation.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentationExists(id))
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

        // POST: api/Documentations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Documentation>> PostDocumentation(Documentation documentation)
        {
            _context.Documentation.Add(documentation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentation", new { id = documentation.Id }, documentation);
        }

        // DELETE: api/Documentations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Documentation>> DeleteDocumentation(Guid id)
        {
            var documentation = await _context.Documentation.FindAsync(id);
            if (documentation == null)
            {
                return NotFound();
            }

            _context.Documentation.Remove(documentation);
            await _context.SaveChangesAsync();

            return documentation;
        }

        private bool DocumentationExists(Guid id)
        {
            return _context.Documentation.Any(e => e.Id == id);
        }
    }
}
