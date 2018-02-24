using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.UI.Models;
using Forum.Domain.Entities;

namespace Forum.UI.Extensions
{
    public static class ViewExtensions
    {
        public static ViewModel ToModel(this View view)
        {
            return ConvertToModel(view);
        }

        public static View ToEntity(this ViewModel model)
        {
            return ConvertToEntity(model);
        }

        public static List<ViewModel> ToModels(this List<View> views)
        {
            if (views == null || views.Count <= 0)
            {
                return new List<ViewModel>();
            }

            List<ViewModel> models = new List<ViewModel>();
            foreach (View view in views)
            {
                if (view != null)
                {
                    models.Add(ConvertToModel(view));
                }
            }

            return models;
        }

        public static List<View> ToEntities(this List<ViewModel> models)
        {
            if (models == null || models.Count <= 0)
            {
                return new List<View>();
            }

            List<View> views = new List<View>();
            foreach (ViewModel model in models)
            {
                if (model != null)
                {
                    views.Add(ConvertToEntity(model));
                }
            }

            return views;
        }

        private static ViewModel ConvertToModel(this View view)
        {
            ViewModel model = new ViewModel();
            if (view != null)
            {
                model.Id = view.Id;
                model.User = view.User;
                model.On = view.On;
                model.Post = view.Post;
            }

            return model;
        }

        private static View ConvertToEntity(ViewModel model)
        {
            if (model == null)
            {
                return new View();
            }

            View view = new View();
            view.On = model.On;
            view.UserId = model.User.Id;
            view.PostId = model.Post.Id;
            view.Id = model.Id;

            return view;
        }




    }
}