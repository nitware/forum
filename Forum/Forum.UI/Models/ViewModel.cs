using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.Domain.Entities;

namespace Forum.UI.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            Post = new Post();
            User = new User();
        }

        public int Id { get; set; }
        public DateTime On { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }



}