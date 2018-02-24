using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities;

namespace Forum.Service.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(Guid id);
        Category Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }





}
