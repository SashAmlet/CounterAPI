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
        private readonly PageItemsContext _context;
        private readonly IRepository<PageItem, PageItemsContext> _pageItemRepository;
        IRepository<LanguageList, CounterAPIContext> _languageListRepository;

        public PageItemsController(PageItemsContext context, IRepository<PageItem, PageItemsContext> pageItemRepository, IRepository<LanguageList, CounterAPIContext> languageListRepository)
        {
            _context = context;
            _pageItemRepository = pageItemRepository;
            _languageListRepository = languageListRepository;
        }

        // GET: api/PageItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageItem>>> GetPageItems()
        {
            try
            {
                /*var languages = await _languageListRepository.GetAllAsync();

                foreach (var language in languages)
                {
                    var item = new PageItem();
                    item.Name = "option";
                    item.ParentId = 5;
                    item.Value = language.Name;
                    item.Text = language.Name;
                    await _pageItemRepository.AddAsync(item);

                }*/
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
