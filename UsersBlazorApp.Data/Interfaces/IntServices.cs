using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Interfaces
{
    public interface IntServices<I>
    {
        Task<List<I>> GetAll();
        Task<I> Get(int id);
        Task<I> Add(I user);
        Task<bool> Update(I user);
        Task<bool> Delete(int id);
    }
}
