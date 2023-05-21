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
        public async Task<IActionResult> GetPageItems()
        {
            try
            {
                var items = await _pageItemRepository.GetAllAsync();
                return StatusCode(200, items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/PageItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPageItem(int id)
        {
            try
            {
                var item = await _pageItemRepository.GetByIdAsync(id);
                return StatusCode(200, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
