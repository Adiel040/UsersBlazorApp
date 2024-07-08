using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersBlazorApp.API.Context;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRoleClaimsController : ControllerBase
    {
        private readonly UsersDbContext _context;

        public AspNetRoleClaimsController(UsersDbContext context)
        {
            _context = context;
        }

        // GET: api/AspNetRoleClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetRoleClaims>>> GetAspNetRoleClaims()
        {
            return await _context.AspNetRoleClaims.ToListAsync();
        }

        // GET: api/AspNetRoleClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetRoleClaims>> GetAspNetRoleClaims(int id)
        {
            var aspNetRoleClaims = await _context.AspNetRoleClaims.FindAsync(id);

            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }

            return aspNetRoleClaims;
        }

        // PUT: api/AspNetRoleClaims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoleClaims(int id, AspNetRoleClaims aspNetRoleClaims)
        {
            if (id != aspNetRoleClaims.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetRoleClaims).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetRoleClaimsExists(id))
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

        [HttpPost]
        public async Task<ActionResult<AspNetRoleClaims>> PostAspNetRoleClaims(AspNetRoleClaims aspNetRoleClaims)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AspNetRoleClaims.Add(aspNetRoleClaims);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAspNetRoleClaims), new { id = aspNetRoleClaims.Id }, aspNetRoleClaims);
        }

        // DELETE: api/AspNetRoleClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetRoleClaims(int id)
        {
            var aspNetRoleClaims = await _context.AspNetRoleClaims.FindAsync(id);
            if (aspNetRoleClaims == null)
            {
                return NotFound();
            }

            _context.AspNetRoleClaims.Remove(aspNetRoleClaims);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetRoleClaimsExists(int id)
        {
            return _context.AspNetRoleClaims.Any(e => e.Id == id);
        }
    }
}
