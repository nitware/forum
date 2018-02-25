using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities.Core;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }


    }
}
