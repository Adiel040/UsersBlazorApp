using System.Net.Http.Json;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;
using System.Text.Json;

namespace UserBlazorApp.UI.Services
{
    public class UserServices(HttpClient httpClient) : IntServices<AspNetUsers>
    {
        public async Task<List<AspNetUsers>> GetAll()
        {
            var response = await httpClient.GetAsync("api/AspNetUsers");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AspNetUsers>>();
        }

        public async Task<AspNetUsers> Get(int id)
        {
            var response = await httpClient.GetAsync($"api/AspNetUsers/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AspNetUsers>();
        }

        public async Task<AspNetUsers> Add(AspNetUsers user)
        {
            var response = await httpClient.PostAsJsonAsync("api/AspNetUsers", user);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AspNetUsers>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar usuario: {errorContent}");
            }
        }

        public async Task<bool> Update(AspNetUsers user)
        {
            var response = await httpClient.PutAsJsonAsync($"api/AspNetUsers/{user.UserId}", user);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar usuario: {errorContent}");
            }
        }

        public async Task<bool> Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"api/AspNetUsers/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar usuario: {errorContent}");
            }
        }
    }
}
