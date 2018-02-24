using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.UI.Models;
using Forum.Domain.Entities;

namespace Forum.UI.Extensions
{
    public static class CategoryExtensions
    {
        public static CategoryModel ToModel(this Category Category)
        {
            return ConvertToModel(Category);
        }

        public static Category ToEntity(this CategoryModel model)
        {
            return ConvertToEntity(model);
        }

        public static List<CategoryModel> ToModels(this List<Category> categories)
        {
            if (categories == null || categories.Count <= 0)
            {
                return new List<CategoryModel>();
            }

            List<CategoryModel> models = new List<CategoryModel>();
            foreach (Category category in categories)
            {
                if (category != null)
                {
                    models.Add(ConvertToModel(category));
                }
            }

            return models;
        }

        public static List<Category> ToEntities(this List<CategoryModel> models)
        {
            if (models == null || models.Count <= 0)
            {
                return new List<Category>();
            }

            List<Category> comments = new List<Category>();
            foreach (CategoryModel model in models)
            {
                if (model != null)
                {
                    comments.Add(ConvertToEntity(model));
                }
            }

            return comments;
        }

        private static CategoryModel ConvertToModel(this Category Category)
        {
            CategoryModel model = new CategoryModel();
            if (Category != null)
            {
                model.Id = Category.Id;
                model.Name = Category.Name;
                model.Description = Category.Description;
            }

            return model;
        }

        private static Category ConvertToEntity(CategoryModel model)
        {
            if (model == null)
            {
                return new Category();
            }

            Category Category = new Category();
            Category.Description = model.Description;
            Category.Name = model.Name;
            Category.Id = model.Id;

            return Category;
        }




    }
}