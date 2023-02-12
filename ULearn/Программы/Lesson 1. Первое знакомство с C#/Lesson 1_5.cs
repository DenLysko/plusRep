using System;

namespace Lesson_1_5
{
    class Program
    {
        // Лучше не заводить глобальных переменных
        //static int glovalVariable;
        static void Main()
        {
            // Неинициализированная глобальная переменная
            // равна нулю, а локальная неинициализированная
            // не имеет значения по умолчанию; и это 
            // относится не только к int

            // Неправильно
            //int localVariable;

            var localVariable = 0;
            Console.WriteLine(localVariable.ToString());
            localVariable = DoWork();
            Console.WriteLine(localVariable);
        }

        static int DoWork()
        {
            return 10;
        }
    }
    class Sample1
    {
        static void F()
        {
            i = 1;
            Console.WriteLine(i);
        }
        static int i = 0;
    }
}