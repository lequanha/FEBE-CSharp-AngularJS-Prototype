using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FEBEPrototype.Web.Data;
using FEBEPrototype.Web.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FEBEPrototype.Web.DTOs;

namespace FEBEPrototype.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly FEBEPrototypeContext _context;

        public ProjectsController(FEBEPrototypeContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _context.Projects.Where(p => p.UserId == userId).ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = await _context.Projects.FindAsync(id);

            if (project == null || project.UserId != userId)
            {
                return NotFound();
            }

            return project;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(CreateProjectRequest project)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newProject = new Project
            {
                Name = project.Name,
                Description = project.Description,
                UserId = userId,
                Tags = project.Tags,
                ProjectComponents = project.ComponentIds.Select(cId => new ProjectComponent { ComponentId = cId }).ToList()
            };

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = newProject.Id });
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
