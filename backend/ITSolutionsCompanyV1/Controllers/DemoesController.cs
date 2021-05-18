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
    public class DemoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DemoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Demoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demo>>> GetDemos()
        {
            return await _context.Demos.ToListAsync();
        }

        // GET: api/Demoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demo>> GetDemo(Guid id)
        {
            var demo = await _context.Demos.FindAsync(id);

            if (demo == null)
            {
                return NotFound();
            }

            return demo;
        }

        // PUT: api/Demoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemo(Guid id, Demo demo)
        {
            if (id != demo.Id)
            {
                return BadRequest();
            }

            _context.Entry(demo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoExists(id))
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

        // POST: api/Demoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Demo>> PostDemo(Demo demo)
        {
            _context.Demos.Add(demo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemo", new { id = demo.Id }, demo);
        }

        // DELETE: api/Demoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Demo>> DeleteDemo(Guid id)
        {
            var demo = await _context.Demos.FindAsync(id);
            if (demo == null)
            {
                return NotFound();
            }

            _context.Demos.Remove(demo);
            await _context.SaveChangesAsync();

            return demo;
        }

        private bool DemoExists(Guid id)
        {
            return _context.Demos.Any(e => e.Id == id);
        }
    }
}
