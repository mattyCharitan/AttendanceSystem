using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);

        Task<int> Create(T entity);

        Task<int> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
