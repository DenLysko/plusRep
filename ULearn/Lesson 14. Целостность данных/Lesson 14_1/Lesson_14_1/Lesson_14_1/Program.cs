using System;

namespace Lesson_14_1
{
    public class Program 
    {
        public static void Main()
        {
            Test.NotMain();
            WriteStudent();
        }

        private static void WriteStudent()
        {
            // ReadName считает неизвестно откуда имя очередного студента
            var student = new Student { Name = ReadName() };
            Console.WriteLine("student " + FormatStudent(student));
        }

        private static string FormatStudent(Student student)
        {
            return student.Name.ToUpper();
        }

        private static string ReadName()
        {
            return Console.ReadLine();
        }

    }

    public class Student
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value is null) throw new ArgumentException();
                name = value;
            }
        }

    }

}