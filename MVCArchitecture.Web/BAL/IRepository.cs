using PagedList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.BAL
{
    public interface IRepository<T> : IDisposable
    {
        Task<List<T>> GetAll(string sortOrder = null, int pageNumber = 0, int pageSize = 0);
        Task<T> GetById(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<IPagedList<T>> GetSortedPagedList(string sortOrder, int pageNumber, int pageSize);
    }
}