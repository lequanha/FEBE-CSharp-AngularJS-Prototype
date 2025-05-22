using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FEBEPrototype.Web.Data;
using FEBEPrototype.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace FEBEPrototype.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComponentsController : ControllerBase
    {
        private readonly FEBEPrototypeContext _context;

        public ComponentsController(FEBEPrototypeContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            return await _context.Components.ToListAsync();
        }

        // GET: api/Components/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

    }
}
