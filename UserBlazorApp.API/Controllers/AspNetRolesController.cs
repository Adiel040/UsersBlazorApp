using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.Dto.Claims;
using UserBlazorApp.API.Dto.Roles;
using UsersBlazorApp.API.Context;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRolesController : ControllerBase
    {
        private readonly ApiService<AspNetRoles> rApiService;

        public AspNetRolesController(ApiService<AspNetRoles> rApiService)
        {
            this.rApiService = rApiService;
        }

        // GET: api/AspNetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleResponse>>> GetAspNetRoles()
        {
            var roles = await rApiService.GetAll();
            var roleResponses = roles.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name,
                RoleClaim = r.AspNetRoleClaims.Select(rc => new RoleClaimsResponse
                {
                    Id = rc.Id,
                    Claimtype = rc.ClaimType,
                    Claimvalue = rc.ClaimValue
                }).ToList()
            }).ToList();

            return Ok(roleResponses);
        }

        // GET: api/AspNetRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResponse>> GetAspNetRoles(int id)
        {
            var role = await rApiService.Get(id);
            if (role == null)
            {
                return NotFound();
            }

            var roleResponse = new RoleResponse
            {
                Id = role.Id,
                Name = role.Name,
                RoleClaim = role.AspNetRoleClaims.Select(rc => new RoleClaimsResponse
                {
                    Id = rc.Id,
                    Claimtype = rc.ClaimType,
                    Claimvalue = rc.ClaimValue
                }).ToList()
            };

            return Ok(roleResponse);
        }

        // POST: api/AspNetRoles
        [HttpPost]
        public async Task<ActionResult<RoleResponse>> PostAspNetRoles(RoleRequest roleRequest)
        {
            var role = new AspNetRoles
            {
                Name = roleRequest.Name,
                AspNetRoleClaims = roleRequest.RoleClaimReq.Select(rc => new AspNetRoleClaims
                {
                    ClaimType = rc.Claimtype,
                    ClaimValue = rc.Claimvalue
                }).ToList()
            };

            var createdRole = await rApiService.Add(role);

            var roleResponse = new RoleResponse
            {
                Id = createdRole.Id,
                Name = createdRole.Name,
                RoleClaim = createdRole.AspNetRoleClaims.Select(rc => new RoleClaimsResponse
                {
                    Id = rc.Id,
                    Claimtype = rc.ClaimType,
                    Claimvalue = rc.ClaimValue
                }).ToList()
            };

            return CreatedAtAction(nameof(GetAspNetRoles), new { id = createdRole.Id }, roleResponse);
        }

        // PUT: api/AspNetRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoles(int id, RoleRequest roleRequest)
        {
            var role = await rApiService.Get(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = roleRequest.Name;
            role.AspNetRoleClaims = roleRequest.RoleClaimReq.Select(rc => new AspNetRoleClaims
            {
                ClaimType = rc.Claimtype,
                ClaimValue = rc.Claimvalue
            }).ToList();

            var result = await rApiService.Update(role);
            if (!result)
            {
                return BadRequest("Failed to update role");
            }

            return NoContent();
        }

        // DELETE: api/AspNetRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetRoles(int id)
        {
            var result = await rApiService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
