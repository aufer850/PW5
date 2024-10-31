using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW5
{
    public class VideoCourse : Course, IWatchable
    {
        public VideoCourse() { Title = ""; Instructor = ""; Duration = 0;}
        public VideoCourse(string title, string instructor, int duration) 
        { 
        this.Title = title;
        this.Instructor = instructor;
        this.Duration = duration;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Course name: " + Title);
            Console.WriteLine("Instructor's name: " + Instructor);
            Console.WriteLine("Time to watch course: " + Duration +" hours");
        }
        public void Watch()
        {
            Console.WriteLine("Started watching course " + Title);
            Console.WriteLine("You should end your course before " + DateTime.Now + new DateTime(0, 0, 0, Duration, 0, 0));
        }

    }
}
