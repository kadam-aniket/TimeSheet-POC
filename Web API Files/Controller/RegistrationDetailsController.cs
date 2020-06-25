using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationDetailsController : ControllerBase
    {
            private readonly UsersContext _context;
          //  private UserManager<RegistrationDetails> _userManager;
          //  private readonly ApplicationSettings _appSettings;

        public RegistrationDetailsController(UsersContext context)
        {
            _context = context;
           // _userManager = userManager;
           // _appSettings = appSettings.Value;
        }

        // GET: api/RegistrationDetails
        [HttpGet]
        public IEnumerable<RegistrationDetails> GetregistrationDetails()
        {
            return _context.registrationDetails;
        }

        // GET: api/RegistrationDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationDetails = await _context.registrationDetails.FindAsync(id);

            if (registrationDetails == null)
            {
                return NotFound();
            }

            return Ok(registrationDetails);
        }

        // PUT: api/RegistrationDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationDetails([FromRoute] int id, [FromBody] RegistrationDetails registrationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registrationDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(registrationDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationDetailsExists(id))
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

        // POST: api/RegistrationDetails
        [HttpPost]
        public async Task<IActionResult> PostRegistrationDetails([FromBody] RegistrationDetails registrationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.registrationDetails.Add(registrationDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrationDetails", new { id = registrationDetails.Id }, registrationDetails);
        }

        // DELETE: api/RegistrationDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationDetails = await _context.registrationDetails.FindAsync(id);
            if (registrationDetails == null)
            {
                return NotFound();
            }

            _context.registrationDetails.Remove(registrationDetails);
            await _context.SaveChangesAsync();

            return Ok(registrationDetails);
        }

        private bool RegistrationDetailsExists(int id)
        {
            return _context.registrationDetails.Any(e => e.Id == id);
        }

      /*  [HttpPost]
        // api/RegistrationDetails/login
         public async Task<IActionResult>Login(LoginModel model)
         {
              var user = await _userManager.FindByNameAsync(model.UserName);
              if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
              {
                  var tokendescriptor = new SecurityTokenDescriptor
                  {
                      Subject = new ClaimsIdentity(new Claim[]
                      {
                          new Claim("UserId", user.Id.ToString())
                      }),
                      Expires = DateTime.UtcNow.AddMinutes(5),
                      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                  };
                  var tokenHandler =new JwtSecurityTokenHandler();
                  var securityToken = tokenHandler.CreateToken(tokendescriptor);
                  var token = tokenHandler.WriteToken(securityToken);
                  return Ok(new { token });
              }
              else
                  return BadRequest(new { message = "UserName or Password is incorrect" });
         }  */
    } 
}