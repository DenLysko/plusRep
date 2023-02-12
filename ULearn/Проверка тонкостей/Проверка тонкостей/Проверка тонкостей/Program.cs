using System;

namespace Test_1
{
    public class Program
    {
        public static void Main()
        {
            string str = "123";
            FirstMethod(str);
            Console.WriteLine(str);

            int i = 123;
            SecondMethod(i);
            Console.WriteLine(i);
        }

        public static void FirstMethod(string str)
        {
            str += str;
        }

        public static void SecondMethod(int i)
        {
            i += i;
        }
    }
}