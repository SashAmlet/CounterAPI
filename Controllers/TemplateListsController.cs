using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CounterAPI.Context;
using CounterAPI.Models;

namespace CounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateListsController : ControllerBase
    {
        private readonly CounterAPIContext _context;

        public TemplateListsController(CounterAPIContext context)
        {
            _context = context;
        }

        // GET: api/TemplateLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateList>>> GetTemplateLists()
        {
          if (_context.TemplateLists == null)
          {
              return NotFound();
          }
            return await _context.TemplateLists.ToListAsync();
        }

        // GET: api/TemplateLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateList>> GetTemplateList(int id)
        {
          if (_context.TemplateLists == null)
          {
              return NotFound();
          }
            var templateList = await _context.TemplateLists.FindAsync(id);

            if (templateList == null)
            {
                return NotFound();
            }

            return templateList;
        }

        // PUT: api/TemplateLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplateList(int id, TemplateList templateList)
        {
            if (id != templateList.Id)
            {
                return BadRequest();
            }

            _context.Entry(templateList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateListExists(id))
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

        // POST: api/TemplateLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TemplateList>> PostTemplateList(TemplateList templateList)
        {
          if (_context.TemplateLists == null)
          {
              return Problem("Entity set 'CounterAPIContext.TemplateLists'  is null.");
          }
            _context.TemplateLists.Add(templateList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemplateList", new { id = templateList.Id }, templateList);
        }

        // DELETE: api/TemplateLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplateList(int id)
        {
            if (_context.TemplateLists == null)
            {
                return NotFound();
            }
            var templateList = await _context.TemplateLists.FindAsync(id);
            if (templateList == null)
            {
                return NotFound();
            }

            _context.TemplateLists.Remove(templateList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemplateListExists(int id)
        {
            return (_context.TemplateLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
