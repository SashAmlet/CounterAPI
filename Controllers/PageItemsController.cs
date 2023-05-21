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
using Newtonsoft.Json;

namespace CounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageItemsController : ControllerBase
    {
        private readonly IRepository<PageItem, PageItemsContext> _pageItemRepository;

        public PageItemsController(IRepository<PageItem, PageItemsContext> pageItemRepository)
        {
            _pageItemRepository = pageItemRepository;
        }

        // GET: api/PageItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageItem>>> GetPageItems()
        {
            try
            {
                return Ok(await _pageItemRepository.GetAllAsync());
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

        // GET: api/PageItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PageItem>> GetPageItem(int id)
        {
            try
            {
                return Ok(await _pageItemRepository.GetByIdAsync(id));
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
    }
}
