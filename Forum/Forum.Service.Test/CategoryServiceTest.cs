using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Forum.Domain.Entities.Core;
using Forum.Service.Interfaces;
using Forum.Domain.Entities;
using Forum.Data;
using System.Collections.Generic;

namespace Forum.Service.Test
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        public void CanCreateCategoryTest()
        {
            //intialization
            EntityContext context = new EntityContext();
            IRepository<Category> da = new Repository<Category>(context);
            CategoryService categoryService = new CategoryService(da);



            List<Category> categories = categoryService.GetAll();
            int initialRecordCount = categories == null || categories.Count == 0 ? 0 : categories.Count;

            Category category = new Category()
            {
                Name = "Casual",
                Description = "Casual description"
            };

            Category newCategory = categoryService.Create(category);
           


            Category addedCategory = categoryService.GetById(newCategory.Id);
            List<Category> categories2 = categoryService.GetAll();
            int recordCount = categories2 == null || categories2.Count == 0 ? 0 : categories2.Count;

            Assert.IsTrue(recordCount == (initialRecordCount + 1));
            Assert.IsNotNull(newCategory);
            Assert.IsTrue(newCategory.Id == addedCategory.Id);

        }

        

    }


}
