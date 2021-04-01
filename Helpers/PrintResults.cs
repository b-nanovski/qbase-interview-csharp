using System;
using System.Collections.Generic;

namespace Backend.Helpers
{
    public class PrintResults
    {
        public static void Print(List<Tuple<string, int>> countries)
        {
            int counter = 1;
            foreach (Tuple<string, int> country in countries)
            {
                Console.WriteLine(string.Format("{0}. Country: {1}, Population: {2}", counter, country.Item1, country.Item2, Environment.NewLine));

                counter++;
            }
        }
    }
}
