using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forum.Domain.Entities;
using Forum.Service.Interfaces;
using Forum.Domain.Entities.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Forum.Data.Test
{
    [TestClass]
    public class RepositoryTest
    {
        //[TestInitialize]
        //public void Initialize()
        //{
        //    // Setup data context and fake data
        //    _dataContext = new FakeDataContext();
        //    _dataContext.Insert(new Message(1, null, "Robert", "Welcome to the MVC forums!", "body1"));
        //    _dataContext.Insert(new Message(2, 1, "Stephen", "RE:Welcome to the MVC forums!", "body2"));
        //    _dataContext.Insert(new Message(3, 2, "Robert", "RE:Welcome to the MVC forums!", "body3"));
        //    _dataContext.Insert(new Message(4, null, "Mark", "Another message", "body4"));
        //    _dataContext.Insert(new Message(5, 4, "Stephen", "Yet another message", "body5"));
        //    _dataContext.Insert(new Message(6, 5, "Jane", "Yet another message", "body6"));

        //    // Create repository
        //    _repository = new ForumRepository(_dataContext);
        //}


        [TestMethod]
        public void AddCategoryMethod()
        {
            EntityContext context = new EntityContext();
            IRepository<Category> da = new Repository<Category>(context);

            List<Category> categories = da.GetAll();
            int initialRecordCount = categories == null || categories.Count() == 0 ? 0 : categories.Count();

            Category category = new Category()
            {
                //Id = Guid.NewGuid(),
                Name = "Casual-2",
                Description = "Casual description-2"
            };

            da.Add(category);
            da.Save();

            Category newCategory = da.GetById(category.Id);
            List<Category> categories2 = da.GetAll();
            int recordCount = categories2 == null || categories2.Count() == 0 ? 0 : categories2.Count();

            Assert.IsTrue(recordCount == (initialRecordCount + 1));
            Assert.IsNotNull(newCategory);
            Assert.IsTrue(newCategory.Id == category.Id);

        }

        [TestMethod]
        public void UpdateCategoryMethod()
        {
            EntityContext context = new EntityContext();
            IRepository<Category> da = new Repository<Category>(context);

            Expression<Func<Category, bool>> selector = c => c.Name == "Casual-3";

            Category category = da.GetBy(selector).SingleOrDefault();
            category.Name = "Updated!";
            category.Description = "Just updated!!!";

            da.Edit(category);
            da.Save();

            //assert
            Category updatedCategory = da.GetById(category.Id);

            Assert.IsNotNull(updatedCategory);
            Assert.IsTrue(updatedCategory.Id == category.Id);
            Assert.IsTrue(updatedCategory.Name == category.Name);

        }









        //[TestMethod]
        //public void AddCategoryMethod()
        //{
        //    EntityContext context = new EntityContext();
        //    IRepository da = new Repository(context);

        //    IQueryable<Category> categories = da.GetAll<Category>();
        //    int initialRecordCount = categories == null || categories.Count() == 0 ? 0 : categories.Count();

        //    Category category = new Category()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Casual-3",
        //        Description = "Casual description-2"
        //    };

        //    da.Add(category);
        //    da.Save();

        //    Category newCategory = da.GetById<Category>(category.Id);
        //    IQueryable<Category> categories2 = da.GetAll<Category>();
        //    int recordCount = categories2 == null || categories2.Count() == 0 ? 0 : categories2.Count();

        //    Assert.IsTrue(recordCount == (initialRecordCount + 1));
        //    Assert.IsNotNull(newCategory);
        //    Assert.IsTrue(newCategory.Id == category.Id);

        //}

        //[TestMethod]
        //public void UpdateCategoryMethod()
        //{
        //    EntityContext context = new EntityContext();
        //    IRepository da = new Repository(context);

        //    Expression<Func<Category, bool>> selector = c => c.Name == "Casual-3";

        //    Category category = da.GetBy(selector).SingleOrDefault();
        //    category.Name = "Updated!";
        //    category.Description = "Just updated!!!";

        //    da.Edit(category);
        //    da.Save();

        //    //assert
        //    Category updatedCategory = da.GetById<Category>(category.Id);

        //    Assert.IsNotNull(updatedCategory);
        //    Assert.IsTrue(updatedCategory.Id == category.Id);
        //    Assert.IsTrue(updatedCategory.Name == category.Name);

        //}









    }








}
