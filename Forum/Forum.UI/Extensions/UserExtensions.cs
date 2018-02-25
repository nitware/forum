using Forum.Domain.Entities;
using Forum.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.UI.Extensions
{
    public static class UserExtensions
    {
        public static User ToEntity(this UserModel model)
        {
            return ConvertToEntity(model);
        }

        public static UserModel ToModel(this User user)
        {
            return ConvertToModel(user);
        }

        public static List<UserModel> ToModels(this List<User> users)
        {
            if (users == null || users.Count <= 0)
            {
                return new List<Models.UserModel>();
            }

            List<UserModel> models = new List<UserModel>();
            foreach (User user in users)
            {
                if (user != null)
                {
                    models.Add(ConvertToModel(user));
                }
            }

            return models;
        }
        public static List<User> ToEntities(this List<UserModel> models)
        {
            if (models == null || models.Count <= 0)
            {
                return new List<User>();
            }

            List<User> users = new List<User>();
            foreach (UserModel model in models)
            {
                if (model != null)
                {
                    users.Add(ConvertToEntity(model));
                }
            }

            return users;
        }

        private static UserModel ConvertToModel(User user)
        {
            if (user == null)
            {
                return new UserModel();
            }

            UserModel model = new Models.UserModel();
            model.Id = user.Id;
            model.Name = user.Name;
            model.Email = user.Email;
            model.Salt = user.Salt;
            model.IsLocked = user.IsLocked;
            model.CreatedOn = user.CreatedOn;
            model.LastUpdatedOn = user.LastUpdatedOn;
            model.HashedPassword = user.HashedPassword;
            model.Role = user.Role;

            return model;
        }

        private static User ConvertToEntity(UserModel model)
        {
            if (model == null)
            {
                return new User();
            }

            User user = new User();
            user.Id = model.Id;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Salt = model.Salt;
            user.IsLocked = model.IsLocked;
            user.CreatedOn = model.CreatedOn;
            user.LastUpdatedOn = model.LastUpdatedOn;
            user.HashedPassword = model.HashedPassword;
            user.Role = model.Role;

            return user;
        }




    }
}