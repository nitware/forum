using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Forum.Service.Interfaces;

namespace Forum.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public List<T> GetAll(string includePropertiesString)
        {
            IQueryable<T> entities = _context.Set<T>();
            string[] includeProperties = includePropertiesString.Split(',');
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }

            return entities.ToList();
        }
        public async Task<List<T>> GetAllAsync(string includePropertiesString)
        {
            IQueryable<T> entities = _context.Set<T>();
            string[] includeProperties = includePropertiesString.Split(',');
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }

            return await entities.ToListAsync();
        }


        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
       
        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
        public List<T> GetBy(Expression<Func<T, bool>> predicate, string includePropertiesString)
        {
            IQueryable<T> entities = _context.Set<T>().Where(predicate);
            string[] includeProperties = includePropertiesString.Split(',');
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            
            return entities.ToList();
        }
        public T GetSingleBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                T entity = null;
                IQueryable<T> entities = _context.Set<T>().Where(predicate);
                if (entities != null && entities.Count() > 0)
                {
                    if (entities.Count() == 1)
                    {
                        entity = entities.SingleOrDefault();
                    }
                    else
                    {
                        throw new Exception("Criteria returned more than one result set! Please contact your system administrator.");
                    }

                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetSingleBy(Expression<Func<T, bool>> predicate, string includePropertiesString)
        {
            try
            {
                T entity = null;
                IQueryable<T> entities = _context.Set<T>().Where(predicate);
                string[] includeProperties = includePropertiesString.Split(',');
                foreach (var includeProperty in includeProperties)
                {
                    entities = entities.Include(includeProperty);
                }

                if (entities != null && entities.Count() > 0)
                {
                    if (entities.Count() == 1)
                    {
                        entity = entities.SingleOrDefault();
                    }
                    else
                    {
                        throw new Exception("Criteria returned more than one result set! Please contact your system administrator.");
                    }
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        public void Delete(int id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string exp = ex.EntityValidationErrors.ToString();
            }

        }



    }




    //public class Repository : IRepository
    //{
    //    private readonly DbContext _context;

    //    public Repository(DbContext context)
    //    {
    //        if (context == null)
    //        {
    //            throw new ArgumentNullException("context");
    //        }

    //        _context = context;
    //    }

    //    public IQueryable<T> GetAll<T>() where T : class
    //    {
    //        return _context.Set<T>();
    //    }

    //    public T GetById<T>(Guid id) where T : class
    //    {
    //        return _context.Set<T>().Find(id);
    //    }

    //    public IQueryable<T> GetBy<T>(Expression<Func<T, bool>> predicate) where T : class
    //    {
    //        return _context.Set<T>().Where(predicate);
    //    }

    //    public T GetSingleBy<T>(Expression<Func<T, bool>> predicate) where T : class
    //    {
    //        try
    //        {
    //            T entity = null;
    //            IQueryable<T> entities = _context.Set<T>().Where(predicate);
    //            if (entities != null && entities.Count() > 0)
    //            {
    //                if (entities.Count() == 1)
    //                {
    //                    entity = entities.SingleOrDefault();
    //                }
    //                else
    //                {
    //                    throw new Exception("Criteria returned more than one result set! Please contact your system administrator.");
    //                }

    //            }

    //            return entity;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    public void Add<T>(T entity) where T : class
    //    {
    //        _context.Set<T>().Add(entity);
    //    }

    //    public void Delete<T>(T entity) where T : class
    //    {
    //        DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
    //        dbEntityEntry.State = EntityState.Deleted;
    //    }

    //    public void Edit<T>(T entity) where T : class
    //    {
    //        DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
    //        dbEntityEntry.State = EntityState.Modified;
    //    }

    //    public void Save()
    //    {
    //        _context.SaveChanges();
    //    }



    //}












}
