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
        private readonly IRepository<TemplateList, CounterAPIContext> _templateListRepository;

        public TemplateListsController(CounterAPIContext context, IRepository<TemplateList, CounterAPIContext> templateListRepository)
        {
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
            try
            {
                return Ok(await _templateListRepository.GetByIdAsync(id));
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

        // PUT: api/TemplateLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplateList(int id, TemplateList templateList)
        {
            try
            {
                await _templateListRepository.UpdateAsync(id, templateList);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/TemplateLists
        [HttpPost]
        public async Task<ActionResult> PostTemplateList(TemplateList templateList)
        {
            if (_templateListRepository.GetAllAsync() == null)
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
            try
            {
                await _templateListRepository.DeleteAsync(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch
            {
                throw;
            }
            return NoContent();
        }
    }
}
