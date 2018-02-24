using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities.Core;

namespace Forum.Domain.Entities
{
    public class View : BaseEntity
    {
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public DateTime On { get; set; }

        public Person User { get; set; }
        public Post Post { get; set; }
    }
}
