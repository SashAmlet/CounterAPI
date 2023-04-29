using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CounterAPI.Context;
using CounterAPI.Models;
using CounterAPI.Repository;

namespace CounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateListsController : ControllerBase
    {
        private readonly CounterAPIContext _context;
        private readonly IRepository<TemplateList, CounterAPIContext> _templateListRepository;

        public TemplateListsController(CounterAPIContext context, IRepository<TemplateList, CounterAPIContext> templateListRepository)
        {
            _context = context;
            _templateListRepository = templateListRepository;
        }

        // GET: api/TemplateLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateList>>> GetTemplateLists()
        {
            try
            {
                return Ok(await _templateListRepository.GetAllAsync());
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch
            {
                throw;
            }
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
        public async Task<ActionResult> PostTemplateList(TemplateList templateList)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CounterAPIContext.Users'  is null.");
            }
            await _templateListRepository.AddAsync(templateList);

            return NoContent();
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
