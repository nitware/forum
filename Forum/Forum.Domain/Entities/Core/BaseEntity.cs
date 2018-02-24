﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Entities.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
