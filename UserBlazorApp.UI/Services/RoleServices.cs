using System.Net.Http.Json;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI.Services
{
    public class RoleServices(HttpClient httpClient) : IntServices<AspNetRoles>
    {
        public async Task<List<AspNetRoles>> GetAll()
        {
            var response = await httpClient.GetAsync("api/AspNetRoles");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AspNetRoles>>();
        }
        public async Task<AspNetRoles>Get(int id)
        {
            var response = await httpClient.GetAsync($"api/AspNetRoles/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AspNetRoles>();
        }
        public async Task<AspNetRoles> Add(AspNetRoles rol)
        {
            var response = await httpClient.PostAsJsonAsync("api/AspNetRoles", rol);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AspNetRoles>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar el rol: {errorContent}");
            }
        }

        public async Task<bool> Update(AspNetRoles rol)
        {
            var response = await httpClient.PutAsJsonAsync($"api/AspNetRoles/{rol.Id}", rol);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar el rol: {errorContent}");
            }
        }
        public async Task<bool> Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"api/AspNetRoles/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar rol: {errorContent}");
            }
        }
    }
}
