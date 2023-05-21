﻿using System;
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

        public ThemeListsController(CounterAPIContext context, IExtendedRepository<ThemeList, CounterAPIContext> themeListRepository)
        {
            _themeListRepository = themeListRepository;
        }

        // GET: api/ThemeLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemeList>>> GetUserThemes()
        {
            try
            {
                return Ok(await _themeListRepository.GetAllAsync());
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

        // GET: api/ThemeLists/5
        [HttpGet("{theme}")]
        public async Task<ActionResult<int>> GetThemeList(string theme)
        {
            try
            {
                return Ok(await _themeListRepository.GetByNameAsync(theme));
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
