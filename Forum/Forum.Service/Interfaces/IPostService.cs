using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities;

namespace Forum.Service.Interfaces
{
    public interface IPostService
    {
        List<Post> GetAll(string includeProperties = null);
        Task<List<Post>> GetAllAsync(string includeProperties = null);
        Post GetBy(int id, string includeProperties);
        Post GetById(int id);
        Post GetByCategory(Category category);
        Post Create(Post post);
        void Update(Post post);
        void Delete(Post post);
    }



}
