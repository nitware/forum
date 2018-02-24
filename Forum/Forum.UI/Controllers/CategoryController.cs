using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Forum.Service;
using Forum.Domain.Entities;
using Forum.UI.Extensions;

namespace Forum.UI.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly BaseService<Category> _categoryService;

        public CategoryController(BaseService<Category> categoryService)
        {
            if (categoryService == null)
            {
                throw new ArgumentNullException("categoryService");
            }

            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public ActionResult GetCategoryList()
        {
            List<Category> categories = _categoryService.GetAll();
            return PartialView("_CategoryList", categories.ToModels());
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}