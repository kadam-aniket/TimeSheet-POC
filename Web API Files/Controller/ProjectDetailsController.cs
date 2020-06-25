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
    public class ProjectDetailsController : ControllerBase
    {
        private readonly UsersContext _context;

        public ProjectDetailsController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/ProjectDetails
        [HttpGet]
        public IEnumerable<ProjectDetail> GetProjectDetails()
        {
            return _context.ProjectDetails;
        }

        // GET: api/ProjectDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectDetail = await _context.ProjectDetails.FindAsync(id);

            if (projectDetail == null)
            {
                return NotFound();
            }

            return Ok(projectDetail);
        }

        // PUT: api/ProjectDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectDetail([FromRoute] int id, [FromBody] ProjectDetail projectDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectDetail.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectDetailExists(id))
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

        // POST: api/ProjectDetails
        [HttpPost]
        public async Task<IActionResult> PostProjectDetail([FromBody] ProjectDetail projectDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectDetails.Add(projectDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectDetail", new { id = projectDetail.ProjectId }, projectDetail);
        }

        // DELETE: api/ProjectDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectDetail = await _context.ProjectDetails.FindAsync(id);
            if (projectDetail == null)
            {
                return NotFound();
            }

            _context.ProjectDetails.Remove(projectDetail);
            await _context.SaveChangesAsync();

            return Ok(projectDetail);
        }

        private bool ProjectDetailExists(int id)
        {
            return _context.ProjectDetails.Any(e => e.ProjectId == id);
        }
    }
}
