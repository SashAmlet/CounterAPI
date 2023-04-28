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
    public class LanguageListsController : ControllerBase
    {
        private readonly CounterAPIContext _context;
        private readonly IRepository<LanguageList, CounterAPIContext> _languageListRepository;

        public LanguageListsController(CounterAPIContext context, IRepository<LanguageList, CounterAPIContext> languageListRepository)
        {
            _context = context;
            _languageListRepository = languageListRepository;
        }

        // GET: api/LanguageLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageList>>> GetUserLanguages()
        {
            try
            {
                return Ok(await _languageListRepository.GetAllAsync());
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

        // GET: api/LanguageLists/5
        [HttpGet("{language}")]
        public async Task<ActionResult<int>> GetLanguageId(string language)
        {
            try
            {
                return Ok(await _context.UserLanguages.Where(a=>a.Name == language).Select(b=>b.Id).FirstAsync());
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
