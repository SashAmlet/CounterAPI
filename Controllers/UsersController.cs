using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CounterAPI.Models;
using CounterAPI.Context;
using CounterAPI.Repository;

namespace CounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IExtendedRepository<User, CounterAPIContext> _userRepository;

        public UsersController(IExtendedRepository<User, CounterAPIContext> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return StatusCode(200, users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{user}")]
        public async Task<IActionResult> GetUser(string user)
        {
            try
            {
                var User = await _userRepository.GetByNameAsync(user);
                return StatusCode(200, User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userRepository.UpdateAsync(id, user);
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

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userRepository.AddAsync(user);
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
