using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string to test!");
            var input = Console.ReadLine();
            Console.WriteLine(IsPerfectString(input));
        }

        static bool IsPerfectString(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return true;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            // populate the dictionary with the frequesncy of wach character
            foreach(char c in str)
            {
                if (keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs[c] += 1;
                }
                else
                {
                    keyValuePairs[c] = 1;
                }

            }

            var disticntResult = keyValuePairs.Values.Distinct(); // take the distnct count of chars.
            if (disticntResult.Count() > 2) return false; // when distinct char count is > 2
            if (disticntResult.Count() == 1) return true; // all the counts are same, no need to perform any deletion

            return keyValuePairs.Values.GroupBy(i => i).Where(i => i.Count() == 1).Count() == 1;
        }
    }
}
