using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Create(T obj);
        void Delete(Guid id);
        void Update(T obj);
        IEnumerable<T> GetAll();

    }
}