using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Entities;
using Forum.Service.Interfaces;

namespace Forum.Service
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            _postRepository = postRepository;
        }

        public Post Create(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }
                        
            post.DatePosted = DateTime.UtcNow;

            _postRepository.Add(post);
            _postRepository.Save();

            return post;
        }

        public async Task<List<Post>> GetAllAsync(string includeProperties = null)
        {
            List<Post> posts = null;
            if (string.IsNullOrWhiteSpace(includeProperties))
            {
                posts = await _postRepository.GetAllAsync();
            }
            else
            {
                posts = await _postRepository.GetAllAsync(includeProperties);
            }

            return posts;
        }

        public List<Post> GetAll(string includeProperties = null)
        {
            List<Post> posts = null;
            if (string.IsNullOrWhiteSpace(includeProperties))
            {
                posts = _postRepository.GetAll();
            }
            else
            {
                posts = _postRepository.GetAll(includeProperties);
            }

            return posts;
        }

        public Post GetByCategory(Category category)
        {
            return _postRepository.GetSingleBy(p => p.CategoryId == category.Id);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }
        public Post GetBy(int id, string includeProperties)
        {
            return _postRepository.GetSingleBy(p => p.Id == id, includeProperties);
        }

        public void Delete(Post post)
        {
            Post existingPost = GetById(post.Id);
            if (existingPost != null)
            {
                _postRepository.Delete(post);
                _postRepository.Save();
            }
        }

        public void Update(Post post)
        {
            Post existingPost = GetById(post.Id);
            if (existingPost != null)
            {
                _postRepository.Edit(post);
                _postRepository.Save();
            }
        }
    }




}
