using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Service.Interfaces;
using Forum.Domain.Entities.Core;

namespace Forum.Service
{
    public abstract class BaseService<T> where T : class, new()
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public T Create(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("post");
            }

            //model = SetNewGuid(model);

            _repository.Add(model);
            _repository.Save();

            return model;
        }

        //public abstract T SetNewGuid(T model);
       
        public List<T> GetAll()
        {
            return _repository.GetAll();
        }
               
        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public void Update(T model)
        {
            _repository.Edit(model);
            _repository.Save();
        }




    }



}

