using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly UsersContext _context;

        public UserDetailController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/UserDetail
        [HttpGet]
        public IEnumerable<UserDetails> GetuserDetails()
        {
            return _context.userDetails;
        }

        // GET: api/UserDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDetails = await _context.userDetails.FindAsync(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

        // PUT: api/UserDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetails([FromRoute] int id, [FromBody] UserDetails userDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userDetails.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDetail
        [HttpPost]
        public async Task<IActionResult> PostUserDetails([FromBody] UserDetails userDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.userDetails.Add(userDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetails", new { id = userDetails.UserId }, userDetails);
        }

        // DELETE: api/UserDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDetails = await _context.userDetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            _context.userDetails.Remove(userDetails);
            await _context.SaveChangesAsync();

            return Ok(userDetails);
        }

        private bool UserDetailsExists(int id)
        {
            return _context.userDetails.Any(e => e.UserId == id);
        }
    }
}