using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.UI.Models;
using Forum.Domain.Entities;

namespace Forum.UI.Extensions
{
    public static class PostExtentions
    {
        public static PostModel ToModel(this Post post)
        {
            return ConvertToModel(post);
        }

        public static Post ToEntity(this PostModel model)
        {
            return ConvertToEntity(model);
        }

        public static List<PostModel> ToModels(this List<Post> posts)
        {
            if (posts == null || posts.Count <= 0)
            {
                return new List<Models.PostModel>();
            }

            List<PostModel> models = new List<PostModel>();
            foreach (Post post in posts)
            {
                if (post != null)
                {
                    models.Add(ConvertToModel(post));
                }
            }

            return models;
        }

        public static List<Post> ToEntities(this List<PostModel> models)
        {
            if (models == null || models.Count <= 0)
            {
                return new List<Post>();
            }

            List<Post> posts = new List<Post>();
            foreach (PostModel model in models)
            {
                if (model != null)
                {
                    posts.Add(ConvertToEntity(model));
                }
            }

            return posts;
        }

        private static PostModel ConvertToModel(Post post)
        {
            PostModel model = new PostModel();
            if (post != null)
            {
                model.DatePosted = post.DatePosted;
                model.Category = post.Category;
                model.Subject = post.Subject;
                model.User = post.Person;
                model.Body = post.Body;
                model.Id = post.Id;
                model.Comments = post.Comments != null ? post.Comments.ToModels() : null;
                model.ReplyCount = post.Comments != null && post.Comments.Count > 0 ? post.Comments.Count : 0;
                model.ViewCount = post.Views != null && post.Views.Count > 0 ? post.Views.Count : 0;
            }

            return model;
        }

        private static Post ConvertToEntity(PostModel model)
        {
            if (model == null)
            {
                return new Post();
            }

            Post post = new Post();
            post.DatePosted = model.DatePosted;
            post.CategoryId = model.Category.Id;
            post.Subject = model.Subject;
            post.PersonId = model.User.Id;
            post.Body = model.Body;
            post.Id = model.Id;

            return post;
        }






    }




}