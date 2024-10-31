using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW5
{
    public abstract class Course
    {
        public string Title { get; set; }
        public string Instructor { get; set; }
        public int Duration { get; set; }
        public abstract void DisplayInfo();
    }
}
