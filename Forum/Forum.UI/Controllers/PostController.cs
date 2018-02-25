using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Forum.UI.Extensions;
using Forum.Service.Interfaces;
using Forum.Domain.Entities;
using Forum.UI.Models;
using Forum.Service;
using System.Threading.Tasks;

namespace Forum.UI.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly IRepository<Comment> _commentService;
        private readonly BaseService<Category> _categoryService;
        private readonly IRepository<View> _viewService;

        public PostController(IPostService postService, BaseService<Category> categoryService, IRepository<Comment> commentService, IRepository<View> viewService)
        {
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }
            if (categoryService == null)
            {
                throw new ArgumentNullException("categoryService");
            }
            if (commentService == null)
            {
                throw new ArgumentNullException("commentService");
            }
            if(viewService == null)
            {
                throw new ArgumentNullException("viewService");
            }

            _postService = postService;
            _viewService = viewService;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public ActionResult GetLatestPost()
        {
            List<Post> posts = _postService.GetAll();
            if (posts != null && posts.Count > 0)
            {
                posts = posts.OrderByDescending(p => p.DatePosted).Take(5).ToList();
            }

            return PartialView("_LatestPosts", posts.ToModels());
        }

        //[AllowAnonymous]
        //public async Task<ActionResult> GetLatestPost()
        //{
        //    List<Post> posts = await _postService.GetAllAsync();
        //    if (posts != null && posts.Count > 0)
        //    {
        //        posts = posts.OrderByDescending(p => p.DatePosted).Take(5).ToList();
        //    }

        //    return PartialView("_LatestPosts", posts.ToModels());
        //}

        //[AllowAnonymous]
        //public ActionResult Index()
        //{
        //    List<Post> posts = _postService.GetAll("Person,Comments,Views");
        //    if (posts != null && posts.Count > 0)
        //    {
        //        posts = posts.OrderByDescending(p => p.DatePosted).ToList();
        //    }

        //    return View(posts.ToModels());
        //}

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            List<Post> posts = await _postService.GetAllAsync("User,Comments,Views");
            if (posts != null && posts.Count > 0)
            {
                posts = posts.OrderByDescending(p => p.DatePosted).ToList();
            }

            return View(posts.ToModels());
        }

        [AllowAnonymous]
        public ActionResult Detail(int pid)
        {
            Post post = _postService.GetBy(pid, "Category,User");
            PostModel postModel = post.ToModel();

            List<Comment> comments = _commentService.GetBy(p => p.PostId == pid, "User");
            postModel.Comments = comments.ToModels();
            
            LogView(post);
            
            return View(postModel);
        }

        private void LogView(Post post)
        {
            try
            {
                View view = new Domain.Entities.View();
                view.On = DateTime.UtcNow;
                view.PostId = post.Id;

                if (LoggedInUser != null && LoggedInUser.Id > 0)
                {
                    view.UserId = LoggedInUser.Id;
                }

                _viewService.Add(view);
                _viewService.Save();
            }
            catch (Exception)
            {
                //log error
            }
        }

        [HttpPost]
        public ActionResult Detail(PostModel model)
        {
            ModelState.Remove("Body");
            ModelState.Remove("Subject");

            if (ModelState.IsValid)
            {
                model.Comment.User = LoggedInUser;
                model.Comment.DatePosted = DateTime.UtcNow;
                model.Comment.Post = new Post() { Id = model.Id };

                _commentService.Add(model.Comment.ToEntity());
                _commentService.Save();

                List<Comment> comments = _commentService.GetBy(p => p.PostId == model.Id, "User");
                model.Comments = comments.ToModels();
            }

            return PartialView("_Comments", model);
        }

        //[HttpPost]
        ////[ValidateInput(false)]
        //public ActionResult Detail(PostModel model)
        //{
        //    ModelState.Remove("Body");
        //    ModelState.Remove("Subject");

        //    if (ModelState.IsValid)
        //    {
        //        model.Comment.User = LoggedInUser;
        //        model.Comment.DatePosted = DateTime.UtcNow;
        //        model.Comment.Post = new Post() { Id = model.Id };
        //        //model.Comment.User = new Person() { Id = 1, Name = "nn", Email = "z@z.com", HashedPassword = "c", Salt = "lll", CreatedOn = DateTime.Now, RoleId = 1 }; // LoggedInUser;

        //        _commentService.Add(model.Comment.ToEntity());
        //        _commentService.Save();

        //        return RedirectToAction("Detail", "Post", new { pid = model.Id });
        //    }

        //    return View(model);
        //}

        [HttpPost]
        [AllowAnonymous]
        public JsonResult EditComment(int cid, string reply)
        {
            JsonResult json = null;

            try
            {
                Comment comment = _commentService.GetById(cid);
                if (comment != null && comment.Id > 0)
                {
                    comment.Reply = reply;
                    _commentService.Edit(comment);
                    _commentService.Save();

                    json = Json(new { isSuccessful = true, comment = reply }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    json = Json(new { isSuccessful = false, comment = reply }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                json = Json(new { isSuccessful = false, message = ex.Message }, "text/html", JsonRequestBehavior.AllowGet);
            }

            return json;
        }

        public ActionResult Add()
        {
            PostModel model = new PostModel();
            List<Category> categories = _categoryService.GetAll();
           
            model.CategorySelectList = DropdownUtility.LoadModelSelectListBy<Category>(categories, false, "--  Select Category  --");

            TempData["CategorySelectList"] = model.CategorySelectList;
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Add(PostModel model)
        //{
        //    ModelState.Remove("Category.Name");
        //    model.CategorySelectList = (List<SelectListItem>)TempData["CategorySelectList"];

        //    if (ModelState.IsValid)
        //    {
        //        model.User = LoggedInUser;
        //        Post post = _postService.Create(model.ToEntity());
        //        if (post != null && post.Id > 0)
        //        {
        //            return RedirectToAction("Index", "Post");
        //        }
        //    }

        //    TempData["CategorySelectList"] = model.CategorySelectList;
        //    return View(model);
        //}

        [HttpPost]
        public JsonResult Add(PostModel model)
        {
            JsonResult json = null;
            ModelState.Remove("Category.Name");
            model.CategorySelectList = (List<SelectListItem>)TempData["CategorySelectList"];

            if (ModelState.IsValid)
            {
                model.User = LoggedInUser;
                Post post = _postService.Create(model.ToEntity());
                if (post != null && post.Id > 0)
                {
                    json = Json(new { isSuccessful = true, message = "Topic has been successfully created." }, "text/html", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    json = Json(new { isSuccessful = false, message = "Topic creation failed!" }, "text/html", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                json = Json(new { isSuccessful = false, message = "Topic creation failed, due to failure in form validation!" }, "text/html", JsonRequestBehavior.AllowGet);
            }

            TempData["CategorySelectList"] = model.CategorySelectList;
            return json;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





    }
}