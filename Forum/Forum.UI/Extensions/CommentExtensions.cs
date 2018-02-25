using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.UI.Models;
using Forum.Domain.Entities;

namespace Forum.UI.Extensions
{
    public static class CommentExtensions
    {
        public static CommentModel ToModel(this Comment comment)
        {
            return ConvertToModel(comment);
        }

        public static Comment ToEntity(this CommentModel model)
        {
            return ConvertToEntity(model);
        }

        public static List<CommentModel> ToModels(this List<Comment> comments)
        {
            return ToModelsHelper(comments);
        }
        public static List<CommentModel> ToModels(this ICollection<Comment> comments)
        {
            return ToModelsHelper(comments);
        }

        private static List<CommentModel> ToModelsHelper(ICollection<Comment> comments)
        {
            if (comments == null || comments.Count <= 0)
            {
                return new List<CommentModel>();
            }

            List<CommentModel> models = new List<CommentModel>();
            foreach (Comment comment in comments)
            {
                if (comment != null)
                {
                    models.Add(ConvertToModel(comment));
                }
            }

            return models;
        }

        public static List<Comment> ToEntities(this List<CommentModel> models)
        {
            if (models == null || models.Count <= 0)
            {
                return new List<Comment>();
            }

            List<Comment> comments = new List<Comment>();
            foreach (CommentModel model in models)
            {
                if (model != null)
                {
                    comments.Add(ConvertToEntity(model));
                }
            }

            return comments;
        }

        private static CommentModel ConvertToModel(this Comment comment)
        {
            CommentModel model = new CommentModel();
            if (comment != null)
            {
                model.Id = comment.Id;
                model.User = comment.User;
                model.Reply = comment.Reply;
                model.DatePosted = comment.DatePosted;
                model.Post = comment.Post;
            }

            return model;
        }

        private static Comment ConvertToEntity(CommentModel model)
        {
            if (model == null)
            {
                return new Comment();
            }

            Comment comment = new Comment();
            comment.DatePosted = model.DatePosted;
            comment.UserId = model.User.Id;
            comment.Reply = model.Reply;
            comment.PostId = model.Post.Id;
            comment.Id = model.Id;

            return comment;
        }





    }
}