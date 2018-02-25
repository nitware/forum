using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.Domain.Entities;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Forum.UI.Models
{
    public class PostModel
    {
        public PostModel()
        {
            Category = new Category();
            Comment = new CommentModel();
            Comments = new List<CommentModel>();
            CategorySelectList = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
        public CommentModel Comment { get; set; }
        public DateTime DatePosted { get; set; }

        public IList<SelectListItem> CategorySelectList { get; set; }

        public List<CommentModel> Comments { get; set; }
        public int ReplyCount { get; set; }
        public int ViewCount { get; set; }
    }




}