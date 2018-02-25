using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.Domain.Entities;
using System.Web.Mvc;

namespace Forum.UI.Models
{
    public class CommentModel
    {
        public CommentModel()
        {
            Post = new Post();
            User = new User();
        }

        public int Id { get; set; }

        [AllowHtml]
        public string Reply { get; set; }
        public DateTime DatePosted { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }



}