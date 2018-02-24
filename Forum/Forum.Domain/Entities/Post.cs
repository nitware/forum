using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities.Core;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Views = new HashSet<View>();
            Comments = new HashSet<Comment>();
        }

        public int PersonId { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }

        public Category Category { get; set; }
        public Person Person { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<View> Views { get; set; }
        

    }




}
