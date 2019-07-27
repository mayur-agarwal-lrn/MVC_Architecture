using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.BAL
{
    public interface IRepository<T> : IDisposable
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}