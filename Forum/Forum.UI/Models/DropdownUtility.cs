using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Forum.UI.Models
{
    public class DropdownUtility
    {
        public const string ID = "Id";
        public const string NAME = "Name";
        public const string TEXT = "Text";
        public const string VALUE = "Value";
        public const string Select = "-- Select --";

        public static List<SelectListItem> LoadModelSelectListBy<T>(List<T> models, bool isNullable, string defaultText)
        {
            try
            {
                List<SelectListItem> modelListItems = new List<SelectListItem>();
                if (models != null && models.Count > 0)
                {
                    SelectListItem list = new SelectListItem();
                    if (isNullable)
                    {
                        list.Value = "0";
                    }
                    else
                    {
                        list.Value = "";
                    }

                    list.Text = defaultText;
                    modelListItems.Add(list);

                    foreach (T model in models)
                    {
                        SelectListItem selectList = SetModelValue<T>(model);
                        modelListItems.Add(selectList);
                    }
                }

                return modelListItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SelectListItem SetModelValue<T>(T t)
        {
            try
            {
                if (t == null)
                {
                    throw new NullReferenceException("Model cannot be null! Please contact your system administrator.");
                }

                PropertyInfo idPropertyInfo = t.GetType().GetProperty(ID);
                PropertyInfo namePropertyInfo = t.GetType().GetProperty(NAME);

                if (idPropertyInfo == null || namePropertyInfo == null)
                {
                    throw new NullReferenceException("Property Name specified does not exist in the supplied Model! Please contact your system administrator.");
                }

                SelectListItem selectList = new SelectListItem();
                selectList.Value = t.GetType().GetProperty(ID).GetValue(t, null).ToString();
                selectList.Text = t.GetType().GetProperty(NAME).GetValue(t, null).ToString();

                return selectList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SelectListItem SetModelValue<T>(T model, string id, string name)
        {
            try
            {
                if (model == null)
                {
                    throw new NullReferenceException("Model cannot be null! Please contact your system administrator.");
                }

                PropertyInfo idPropertyInfo = model.GetType().GetProperty(id);
                PropertyInfo namePropertyInfo = model.GetType().GetProperty(name);

                if (idPropertyInfo == null || namePropertyInfo == null)
                {
                    throw new NullReferenceException("Property Name specified does not exist in the supplied Model! Please contact your system administrator.");
                }

                SelectListItem selectList = new SelectListItem();
                selectList.Value = model.GetType().GetProperty(id).GetValue(model, null).ToString();
                selectList.Text = model.GetType().GetProperty(name).GetValue(model, null).ToString();

                return selectList;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}