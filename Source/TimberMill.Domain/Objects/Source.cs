﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimberMill.Domain.Objects
{
    public class Source
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Category={1}", Name, Category);
        }
    }
}
