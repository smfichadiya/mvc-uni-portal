﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class IndexVM
    {
        public Students Student { get; set; }
        public IEnumerable<Tasks> Tasks { get; set; }

    }
}