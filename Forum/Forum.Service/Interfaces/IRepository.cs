using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities.Core;
using System.Linq.Expressions;

namespace Forum.Service.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        List<T> GetAll(string includePropertiesString);
        Task<List<T>> GetAllAsync(string includePropertiesString);
        List<T> GetBy(Expression<Func<T, bool>> predicate);
        List<T> GetBy(Expression<Func<T, bool>> predicate, string includePropertiesString);
        T GetSingleBy(Expression<Func<T, bool>> predicate);
        T GetSingleBy(Expression<Func<T, bool>> predicate, string includePropertiesString);
        T GetById(int Id);

        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Edit(T entity);
        void Save();
    }


    //public interface IRepository
    //{
    //    IQueryable<T> GetAll<T>() where T : class;
    //    IQueryable<T> GetBy<T>(Expression<Func<T, bool>> predicate) where T : class;
    //    T GetSingleBy<T>(Expression<Func<T, bool>> predicate) where T : class;
    //    T GetById<T>(Guid Id) where T : class;

    //    void Add<T>(T entity) where T : class;
    //    void Delete<T>(T entity) where T : class;
    //    void Edit<T>(T entity) where T : class;
    //    void Save();


    //}











}
