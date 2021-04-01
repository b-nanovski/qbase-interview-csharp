using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Helpers
{
    public class AccumulateResults
    {
        public static List<Tuple<string, int>> Aggregate(List<Tuple<string, int>> fromSql, List<Tuple<string, int>> fromApi)
        {
            foreach (Tuple<string, int> apiResult in fromApi)
            {
                if (fromSql.Any(r => IsCountryTheSame(r.Item1, apiResult.Item1)) == false)
                {
                    fromSql.Add(apiResult);
                }
            }

            return fromSql;
        }

        private static bool IsCountryTheSame(string country1, string country2)
        {
            if (country1 == "United States of America" || country1 == "U.S.A.")
            {
                country1 = "usa";
            }

            if (country2 == "United States of America" || country2 == "U.S.A.")
            {
                country2 = "usa";
            }

            return country1 == country2;
        }
    }
}
