using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities;

namespace Forum.Domain.Models
{
    public class UserContext
    {
        public User User { get; set; }
        public IPrincipal Principal { get; set; }
    }

}
