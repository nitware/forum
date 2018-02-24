using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Entities;
using Forum.Service.Interfaces;

namespace Forum.Service
{
    public class CommentService : BaseService<Comment>
    {
        //protected readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository) : base(repository)
        {
           
        }

        public List<Comment> GetByPost(Post post)
        {
            return _repository.GetBy(p => p.PostId == post.Id);
        }



    }




}
