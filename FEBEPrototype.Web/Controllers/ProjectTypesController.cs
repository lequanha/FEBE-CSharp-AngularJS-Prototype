using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FEBEPrototype.Web.Data;
using FEBEPrototype.Web.Models;
using Microsoft.AspNetCore.Authorization;
using FEBEPrototype.Web.DTOs;

namespace FEBEPrototype.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectTypesController : ControllerBase
    {
        private readonly FEBEPrototypeContext _context;

        public ProjectTypesController(FEBEPrototypeContext context)
        {
            _context = context;
        }

        // GET: api/ProjectTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTypeResponse>>> GetProjectTypes()
        {
            return await _context
                .ProjectTypes
                .Include(p => p.ProjectTypeComponents)
                .Select(p => new ProjectTypeResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ComponentIds = p.ProjectTypeComponents.Select(pc => pc.ComponentId).ToList()
                }).ToListAsync();
        }

        // GET: api/ProjectTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectType>> GetProjectType(int id)
        {
            var projectType = await _context.ProjectTypes.FindAsync(id);

            if (projectType == null)
            {
                return NotFound();
            }

            return projectType;
        }

        private bool ProjectTypeExists(int id)
        {
            return _context.ProjectTypes.Any(e => e.Id == id);
        }
    }
}
