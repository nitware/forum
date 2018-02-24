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
        public static Person ToEntity(this UserModel model)
        {
            return ConvertToEntity(model);
        }

        public static UserModel ToModel(this Person user)
        {
            return ConvertToModel(user);
        }

        public static List<UserModel> ToModels(this List<Person> users)
        {
            if (users == null || users.Count <= 0)
            {
                return new List<Models.UserModel>();
            }

            List<UserModel> models = new List<UserModel>();
            foreach (Person user in users)
            {
                if (user != null)
                {
                    models.Add(ConvertToModel(user));
                }
            }

            return models;
        }
        public static List<Person> ToEntities(this List<UserModel> models)
        {
            if (models == null || models.Count <= 0)
            {
                return new List<Person>();
            }

            List<Person> users = new List<Person>();
            foreach (UserModel model in models)
            {
                if (model != null)
                {
                    users.Add(ConvertToEntity(model));
                }
            }

            return users;
        }

        private static UserModel ConvertToModel(Person user)
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

        private static Person ConvertToEntity(UserModel model)
        {
            if (model == null)
            {
                return new Person();
            }

            Person user = new Person();
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