using System;

namespace SwitchVeersusIf
{
    public static class Program
    {
        static void Main()
        {
            var watch = DateTime.Now;
            SwitchMethod();
            Console.WriteLine(DateTime.Now - watch);

            watch = DateTime.Now;
            IfMethod();
            Console.WriteLine(DateTime.Now - watch);

        }

        public static void SwitchMethod()
        {
            for (int i = 0; i < 1000000; i++)
            {
                switch(i)
                {
                    case 123:
                        Console.WriteLine(i);
                        break;
                    case 321:
                        Console.WriteLine(i);
                        break;
                    case 1321:
                        Console.WriteLine(i);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void IfMethod()
        {
            for(int i = 0; i < 1000000; i++)
            {
                if(i == 123)
                    Console.WriteLine(i);
                if (i == 321)
                    Console.WriteLine(i);
                if (i == 1321)
                    Console.WriteLine(i);
            }
        }
    }
}