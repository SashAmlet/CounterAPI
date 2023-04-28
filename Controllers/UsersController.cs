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
        private readonly CounterAPIContext _context;

        private readonly IRepository<User, CounterAPIContext> _userRepository;

        public UsersController(CounterAPIContext context, IRepository<User, CounterAPIContext> userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetAllAsync());
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

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                return Ok(await _userRepository.GetByIdAsync(id));
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

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                await _userRepository.UpdateAsync(id, user);
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CounterAPIContext.Users'  is null.");
            }
            await _userRepository.AddAsync(user);

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
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
