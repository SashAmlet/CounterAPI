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
        private readonly IExtendedRepository<LanguageList, CounterAPIContext> _languageListRepository;

        public LanguageListsController(IExtendedRepository<LanguageList, CounterAPIContext> languageListRepository)
        {
            _languageListRepository = languageListRepository;
        }

        // GET: api/LanguageLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageList>>> GetUserLanguages()
        {
            try
            {
                var languages = await _languageListRepository.GetAllAsync();
                return StatusCode(200, languages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/LanguageLists/5
        [HttpGet("{language}")]
        public async Task<ActionResult<int>> GetLanguageId(string language)
        {
            try
            {
                var Language = await _languageListRepository.GetByNameAsync(language);
                return StatusCode(200, Language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
