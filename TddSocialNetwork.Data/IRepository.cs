using System;
using System.Linq;
using System.Linq.Expressions;

namespace TddSocialNetwork.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T obj);
        void Delete(T entity);
        void Save();
    }
}