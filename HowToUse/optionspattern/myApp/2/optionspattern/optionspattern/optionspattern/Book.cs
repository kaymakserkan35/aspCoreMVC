using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace optionspattern.optionspattern
{
    public class Book : IBook
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }

        public void mymethodA()
        {
            throw new NotImplementedException();
        }
    }
}
