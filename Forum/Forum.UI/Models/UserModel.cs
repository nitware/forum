using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Forum.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Forum.UI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(320)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string HashedPassword { get; set; }

        [Required]
        [Compare("HashedPassword")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
                
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
       
        public Role Role { get; set; }

    }




}