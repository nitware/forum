using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Forum.Domain.Entities;

namespace Forum.Domain.Models
{
    public class PersonContext
    {
        public Person User { get; set; }
        public IPrincipal Principal { get; set; }
    }

}
