﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace myApp.entitiy.LibraryEntities
{
    public class CategoryBook
    {
        public Book Book { get; set; }
        public int BookId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }


    }
}
