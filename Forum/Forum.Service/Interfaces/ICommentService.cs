using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities;

namespace Forum.Service.Interfaces
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetById(Guid id);
        Comment GetByUser(User user);
        Comment Create(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }



}
