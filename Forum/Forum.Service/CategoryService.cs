using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Entities;
using Forum.Service.Interfaces;

namespace Forum.Service
{
    public class CategoryService : BaseService<Category>
    {
        public CategoryService(IRepository<Category> categoryRepository) : base(categoryRepository) { }
       
        //public override Category SetNewGuid(Category model)
        //{
        //    model.Id = Guid.NewGuid();
        //    return model;
        //}
    }






    //public class CategoryService : ICategoryService
    //{
    //    private readonly IRepository<Category> _categoryRepository;

    //    public CategoryService(IRepository<Category> categoryRepository)
    //    {
    //        if (categoryRepository == null)
    //        {
    //            throw new ArgumentNullException("categoryRepository");
    //        }

    //        _categoryRepository = categoryRepository;
    //    }

    //    public Category Create(Category category)
    //    {
    //        if (category == null)
    //        {
    //            throw new ArgumentNullException("category");
    //        }

    //        category.Id = Guid.NewGuid();
    //        _categoryRepository.Add(category);

    //        return category;
    //    }

    //    public void Delete(Category category)
    //    {
    //        _categoryRepository.Delete(category);
    //    }

    //    public List<Category> GetAll()
    //    {
    //        return _categoryRepository.GetAll();
    //    }

    //    public Category GetById(Guid id)
    //    {
    //        return _categoryRepository.GetById(id);
    //    }

    //    public void Update(Category category)
    //    {
    //        _categoryRepository.Edit(category);
    //    }
    //}




}
