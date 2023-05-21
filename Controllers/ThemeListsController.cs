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
    public class ThemeListsController : ControllerBase
    {
        private readonly IExtendedRepository<ThemeList, CounterAPIContext> _themeListRepository;

        public ThemeListsController(IExtendedRepository<ThemeList, CounterAPIContext> themeListRepository)
        {
            _themeListRepository = themeListRepository;
        }

        // GET: api/ThemeLists
        [HttpGet]
        public async Task<IActionResult> GetUserThemes()
        {
            try
            {
                var themes = await _themeListRepository.GetAllAsync();
                return StatusCode(200, themes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ThemeLists/5
        [HttpGet("{theme}")]
        public async Task<IActionResult> GetThemeList(string theme)
        {
            try
            {
                var themes = await _themeListRepository.GetByNameAsync(theme);
                return StatusCode(200, themes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
