using System.Net.Http.Json;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI.Services
{
    public class ClaimService : IntServices<AspNetRoleClaims>
    {
        private readonly HttpClient _httpClient;

        public ClaimService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AspNetRoleClaims>> GetAll()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<AspNetRoleClaims>>("api/AspNetRoleClaims");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener los claims: {ex.Message}");
                throw;
            }
        }

        public async Task<AspNetRoleClaims> Get(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<AspNetRoleClaims>($"api/AspNetRoleClaims/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener el claim con ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<AspNetRoleClaims> Add(AspNetRoleClaims rol)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/AspNetRoles", rol);
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentLength == 0)
                {
                    throw new Exception("La respuesta del servidor está vacía.");
                }

                var result = await response.Content.ReadFromJsonAsync<AspNetRoleClaims>();
                if (result == null)
                {
                    throw new Exception("Error deserializando la respuesta.");
                }

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al agregar el claim: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Update(AspNetRoleClaims rol)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/AspNetRoleClaims/{rol.Id}", rol);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar el claim con ID {rol.Id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/AspNetRoleClaims/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar el claim con ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
