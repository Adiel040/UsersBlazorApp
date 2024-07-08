using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.Dto.Claims;
using UserBlazorApp.API.Dto.Roles;
using UserBlazorApp.API.Dto.User;
using UserBlazorApp.UI.Dto.User;
using UsersBlazorApp.API.Context;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserBlazorApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AspNetUsersController(ApiService<AspNetUsers> userService) : ControllerBase
{

    // GET: api/AspNetUsers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AspNetUsers>>> GetAspNetUsers()
    {
        var usuarios = await userService.GetAll();

        var userRespose = usuarios.Select(u => new UserResponse
        {
            Id = u.UserId,
            Name = u.UserName,
            Email = u.Email,
            PasswordHash = u.PasswordHash,
            PhoneNumber = u.PhoneNumber,
            LockoutEnd = u.LockoutEnd,
            Role = u.Role.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name,
                RoleClaim = r.AspNetRoleClaims.Select(c => new RoleClaimsResponse
                {
                    Id = c.Id,
                    RoleId = c.RoleId,
                    Claimtype = c.ClaimType,
                    Claimvalue = c.ClaimValue
                }).ToList()
            }).ToList()
        }).ToList();
        return Ok(userRespose);
    }

    // GET: api/AspNetUsers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetAspNetUsers(int id)
    {
        var usuario = await userService.Get(id);
        if (usuario == null)
        {
            return NotFound();
        }
        var userResponse = new UserResponse
        {
            Id = usuario.UserId,
            Name = usuario.UserName,
            Email = usuario.Email,
            PasswordHash = usuario.PasswordHash,
            PhoneNumber = usuario.PhoneNumber,
            LockoutEnd = usuario.LockoutEnd,
            Role = usuario.Role.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name
            }).ToList()
        };
        return userResponse;
    }

    // PUT: api/AspNetUsers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAspNetUsers(int id, UserRequest userRequest)
    {
        var usuario = await userService.Get(id);
        if (usuario == null)
        {
            return NotFound();
        }
        usuario.UserName = userRequest.UserName;
        usuario.Email = userRequest.Email;
        usuario.PasswordHash = userRequest.PasswordHash;
        usuario.PhoneNumber = userRequest.PhoneNumber;
        usuario.LockoutEnd = userRequest.LockoutEnd;
        var actualizar = await userService.Update(usuario);
        if (actualizar == false)
            return NotFound();

        return Ok();
    }

    // POST: api/AspNetUsers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserResponse>> PostAspNetUsers(UserRequest userRequest)
    {
        var usuario = new AspNetUsers
        {
            UserName = userRequest.UserName,
            Email = userRequest.Email,
            PasswordHash = userRequest.PasswordHash,
            PhoneNumber = userRequest.PhoneNumber,
            LockoutEnd = DateTime.Now
        };
        var crearUsuario = await userService.Add(usuario);
        var userResponse = new UserResponse
        {
            Id = crearUsuario.UserId,
            Name = crearUsuario.UserName,
            Email = crearUsuario.Email,
            PasswordHash = crearUsuario.PasswordHash,
            PhoneNumber = crearUsuario.PhoneNumber,
            LockoutEnd = crearUsuario.LockoutEnd,
            Role = crearUsuario.Role.Select(r => new RoleResponse
            {
                Id = r.Id,
                Name = r.Name
            }).ToList()
        };
        return Ok(userResponse);
    }

    // DELETE: api/AspNetUsers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAspNetUsers(int id)
    {
        var usuario = await userService.Get(id);
        if (usuario == null)
        {
            return NotFound();
        }
        await userService.Delete(id);
        return NoContent();
    }
}
