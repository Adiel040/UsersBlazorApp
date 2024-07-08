using Microsoft.EntityFrameworkCore;
using UsersBlazorApp.API.Context;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Services
{
    public class RoleService(UsersDbContext Contexto) : ApiService<AspNetRoles>
    {
        public async Task<List<AspNetRoles>> GetAll()
        {
            return await Contexto.AspNetRoles.ToListAsync();
        }

        public async Task<AspNetRoles> Get(int id)
        {
            return await Contexto.AspNetRoles.FirstAsync(r => r.Id == id);
        }

        public async Task<AspNetRoles> Add(AspNetRoles rol)
        {
            Contexto.AspNetRoles.Add(rol);
            await Contexto.SaveChangesAsync();
            return rol;
        }

        public async Task<bool> Update(AspNetRoles rol)
        {
            Contexto.Entry(rol).State = EntityState.Modified;
            return await Contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var rol = await Contexto.AspNetRoles.FindAsync(id);
            if (rol != null)
                return false;
            Contexto.AspNetRoles.Remove(rol);
            return await Contexto.SaveChangesAsync() > 0;

        }
    }
}
