using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCurator.Model
{
    class MenuItem
    {
        public string CategoryTitle { get; set; }
        public BookCategory Category { get; set; }

        public override string ToString()
        {
            return CategoryTitle;
        }

    }
}
