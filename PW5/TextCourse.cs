using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW5
{
    public class TextCourse : Course, IReadable
    {
        public TextCourse() { Title = ""; Instructor = ""; Duration = 0; }
        public TextCourse(string title, string instructor, int duration)
        {
            this.Title = title;
            this.Instructor = instructor;
            this.Duration = duration;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Course name: " + Title);
            Console.WriteLine("Instructor's name: " + Instructor);
            Console.WriteLine("Time to read course: " + Duration + "hours");
        }
        public void Read()
        {
            DateTime D = DateTime.Now;
            D = D.AddHours(Duration);
            Console.WriteLine("Started reading course " + Title);
            Console.WriteLine("You should end your course before " + D.ToString());
        }
    }
}
