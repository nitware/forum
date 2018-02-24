using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities.Core;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public int PostId { get; set; }
        public int CommentorId { get; set; }
                
        [Required]
        public string Reply { get; set; }
        public DateTime DatePosted { get; set; }
                
        public Person Commentor { get; set; }
        public Post Post { get; set; }
    }



}
