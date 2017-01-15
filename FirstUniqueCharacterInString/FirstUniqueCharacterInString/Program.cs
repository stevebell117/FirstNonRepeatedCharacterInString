using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUniqueCharacterInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String to check for unique char:");
            string input = Console.ReadLine().ToLower();
            int length = input.Length;

            Dictionary<char, int> entryCounts = new Dictionary<char, int>();

            Method(input, entryCounts);
            
            int earliestIndex = int.MaxValue;
            
            foreach(KeyValuePair<char, int> entry in entryCounts.Where(w => w.Value == 1))
            {
                int temp = earliestIndex;
                if((temp = input.IndexOf(entry.Key)) < earliestIndex)
                {
                    earliestIndex = temp;
                }
            }

            if (earliestIndex != int.MaxValue)
            {
                Console.WriteLine(input[earliestIndex]);
            }
            else
            {
                Console.WriteLine("No unique characters found.");
            }

            Console.ReadKey();
        }

        static void Method(string input, Dictionary<char, int> entryCounts)
        {
            string firstHalf = input.Substring(0, input.Length / 2);
            string secondHalf = input.Substring(input.Length / 2);

            if (input.Length > 2)
            {
                Method(firstHalf, entryCounts);
                Method(secondHalf, entryCounts);
            }
            else
            {
                foreach(char character in input)
                {
                    if (entryCounts.ContainsKey(character) == false)
                    {
                        entryCounts.Add(character, 1);
                    }
                    else
                    {
                        entryCounts[character]++;
                    }
                }
            }
        }
    }
}
