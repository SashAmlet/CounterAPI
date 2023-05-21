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

        public TemplateListsController(IRepository<TemplateList, CounterAPIContext> templateListRepository)
        {
            _templateListRepository = templateListRepository;
        }

        // GET: api/TemplateLists
        [HttpGet]
        public async Task<IActionResult> GetTemplateLists()
        {
            try
            {
                var tlists = await _templateListRepository.GetAllAsync();
                return StatusCode(200, tlists);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/TemplateLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateList(int id)
        {
            try
            {
                var tlist = await _templateListRepository.GetByIdAsync(id);
                return StatusCode(200, tlist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/TemplateLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplateList(int id, TemplateList templateList)
        {
            try
            {
                await _templateListRepository.UpdateAsync(id, templateList);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/TemplateLists
        [HttpPost]
        public async Task<IActionResult> PostTemplateList(TemplateList templateList)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _templateListRepository.AddAsync(templateList);
                    return StatusCode(200);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TemplateLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplateList(int id)
        {
            try
            {
                bool result = await _templateListRepository.DeleteAsync(id);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
