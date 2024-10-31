using System.Data;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
namespace PW5
{
    internal class Program
    {
        public static List<Course> CourseList = new List<Course>(); // список зі всіма курсами
        // методи длязручності програмування меню
        public static void Dash()
        {
            Console.WriteLine("---===============---");
        }
        public static void WaitForInput()
        {
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
        }
        public static void ErrMes()
        {
            Console.WriteLine("Error occured, try again!");
            WaitForInput();
            Console.Clear();
        }
        // методи меню програми
        public static void AddMenu() // меню додання курсу 
        {
            Console.Clear();
            Console.WriteLine("Adding new course");
            Dash();
            while (true)
            {
                try
                {
                    Course C = new TextCourse("s","s",0);
                    Console.WriteLine("Enter course name: ");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter the name of the instructor: ");
                    string Instructor = Console.ReadLine();
                    Console.WriteLine("Enter duration of the course (in hours): ");
                    int duration = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the type of the course\n1 - Text course\n2 - Video course");
                    string Type;
                    while (true)
                    {
                        Type = Console.ReadLine();
                        if (Type == "1" || Type == "2") { break; }
                    }
                    switch (Type)
                    { 
                    case "1": C = new TextCourse(Name,Instructor,duration); break;
                    case "2": C = new VideoCourse(Name,Instructor,duration); break;
                    }
                    CourseList.Add(C);
                    Console.WriteLine("Course was added!");
                    WaitForInput();
                    Console.Clear();
                    break;
                }
                catch
                {
                    ErrMes();
                    Console.Clear();
                    continue;
                }
            }
        }
        public static void ShowList() // показ всіх курсів
        {
            Console.Clear();
            if (CourseList.Count == 0)
            {
                Console.WriteLine("No courses available right now!");
                WaitForInput();
                return;
            }
            Console.WriteLine("List of all the courses: ");
            Dash();
            for (int i = 0; i < CourseList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + CourseList[i].Title);
            }
            WaitForInput();
        }
        public static void StudyCourse() // пошук та вивчення курсу
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Course thiscourse = null;
                    Console.WriteLine("Please write a course name or it's number, or enter 0 to exit");
                    string str = Console.ReadLine();
                    if (str == "0") { return; }
                    int num;
                    if (Char.IsDigit(str.ToCharArray()[0]))
                    {
                        num = Convert.ToInt32(str);
                        thiscourse = CourseList[num - 1];
                    }
                    else
                    {
                        foreach (Course C in CourseList)
                        {
                            if (string.Equals(C.Title.ToLower(),str.ToLower())) thiscourse = C;
                        }
                    }
                    if (thiscourse != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Course menu");
                        Dash();
                        thiscourse.DisplayInfo();
                        Dash();
                        Console.WriteLine("Do you want to study this course?\n1. Yes\n2. No");
                        while (true)
                        {
                            try
                            {
                                int N = Convert.ToInt32(Console.ReadLine());
                                if (N == 1)
                                {
                                    if (thiscourse is TextCourse)
                                    {
                                        TextCourse T = thiscourse as TextCourse;
                                        T.Read();
                                    } else
                                    {
                                        VideoCourse T = thiscourse as VideoCourse;
                                        T.Watch();
                                    }
                                    Console.ReadKey();
                                } 
                                
                                break;
                            }
                            catch
                            {
                                ErrMes();
                                continue;
                            }
                        }
                    }
                    break;
                } catch {
                    ErrMes();
                    continue;
                }
            }
        }
        public static void Savecourse() // збереження курсу
        {
            while (true)
            {
                try
                {
                    Console.Clear ();
                    Console.WriteLine("Saving");
                    Dash();
                    Console.WriteLine("Enter a name of your savefile or enter 0 to exit!");
                    string FileName  = Console.ReadLine();
                    if (FileName == "0") { return; }
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Course>), new Type[] {typeof(TextCourse),typeof(VideoCourse)});
                    using (StreamWriter writer = new StreamWriter(FileName))
                    {
                        serializer.Serialize(writer, CourseList);
                    }
                    Console.WriteLine("Your data was saved!");
                    WaitForInput();
                    break;
                }
                catch 
                {
                    ErrMes();
                    continue;
                }
            }
        }
        public static void Loadcourse() // завантаження курсу
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Loading");
                    Dash();
                    Console.WriteLine("Enter a name of your savefile or enter 0 to exit!");
                    string FileName = Console.ReadLine();
                    if (FileName == "0") { return; }
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Course>), new Type[] { typeof(TextCourse), typeof(VideoCourse) });
                    using (StreamReader reader = new StreamReader(FileName))
                    {
                        CourseList = (List<Course>)serializer.Deserialize(reader);
                    }
                    Console.WriteLine("Your data was loaded!");
                    WaitForInput();
                    break;
                }
                catch
                {
                    ErrMes();
                    continue;
                }
            }
        }
        static void Main(string[] args) // головне меню
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Main menu");
                    Dash();
                    Console.WriteLine("1. Add new course");
                    Console.WriteLine("2. See all courses");
                    Console.WriteLine("3. Study Course");
                    Console.WriteLine("4. Save courses");
                    Console.WriteLine("5. Load courses");
                    Console.WriteLine("0. Exit program");
                    int num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 0: Environment.Exit(0); break;
                        case 1: AddMenu(); break;
                        case 2: ShowList(); break;
                        case 3: StudyCourse(); break;
                        case 4: Savecourse(); break;
                        case 5: Loadcourse(); break;
                        default: Console.WriteLine("Wrong number, try again!"); WaitForInput(); break;
                    }
                }
                catch
                {
                    ErrMes();
                    continue;
                }
            }
        }
    }
}
