using Microsoft.EntityFrameworkCore;
using UsersBlazorApp.API.Context;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Services
{
    public class ClaimServices(UsersDbContext Contexto) : ApiService<AspNetRoleClaims>
    {
        public async Task<List<AspNetRoleClaims>> GetAll()
        {
            return await Contexto.AspNetRoleClaims.ToListAsync();
        }
        public async Task<AspNetRoleClaims>Get(int id)
        {
            return await Contexto.AspNetRoleClaims.FirstAsync(x => x.Id == id);
        }
        public async Task<AspNetRoleClaims> Add(AspNetRoleClaims rol)
        {
            try
            {
                Contexto.AspNetRoleClaims.Add(rol);
                await Contexto.SaveChangesAsync();
                return rol;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el rol: {ex.Message}");
                throw; // Puedes lanzar la excepción para que se maneje más arriba en la pila de llamadas
            }
        }

        public async Task<bool>Update(AspNetRoleClaims rol)
        {
            Contexto.Entry(rol).State = EntityState.Modified;
            return await Contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var rol = await Contexto.AspNetRoleClaims.FindAsync(id);
            if (rol == null)
                return false;
            Contexto.AspNetRoleClaims.Remove(rol);
            return await Contexto.SaveChangesAsync() > 0;
        }
    }
}
