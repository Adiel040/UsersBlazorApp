using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Interfaces
{
    public interface ApiService<U>
    {
        Task<List<U>> GetAll();
        Task<U> Get(int id);
        Task<U> Add(U user);
        Task<bool> Update(U user);
        Task<bool> Delete(int id);
    }
}
