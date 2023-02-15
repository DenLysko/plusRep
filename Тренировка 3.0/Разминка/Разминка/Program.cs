using System;

namespace Histogram
{
    public class Program
    {
        static void Main()
        {
            var inputStrings = new List<string>();

            while (true)
            {
                string inputString = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputString))
                    inputStrings.Add(inputString);
                else
                    break;
            }
            var letterDictionary = new Dictionary<char, int>();
            foreach (string inputString in inputStrings)
            {
                char[] letters = inputString.ToCharArray();
                foreach (char letter in letters)
                {
                    if (letter == ' ')
                        continue;

                    if (!letterDictionary.ContainsKey(letter))
                        letterDictionary.Add(letter, 1);
                    else
                        letterDictionary[letter]++;
                }
            }

            foreach (var item in letterDictionary.Keys)
            {
                Console.WriteLine(item + " : " + letterDictionary[item]);
            }
            Console.WriteLine();
            Console.WriteLine();
            var sortedDic = letterDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedDic.Keys)
            {
                Console.WriteLine(item + " : " + sortedDic[item]);
            }

            //


        }
    }
}