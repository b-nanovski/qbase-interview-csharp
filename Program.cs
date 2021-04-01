using Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dbManager = new SqliteDbManager();
            var statService = new ConcreteStatService();

            List<Tuple<string, int>> serviceResults = await statService.GetCountryPopulationsAsync();
            List<Tuple<string, int>> dbResults = await dbManager.GetCountryPopulationsAsync();

            List<Tuple<string, int>> results = AccumulateResults.Aggregate(dbResults, serviceResults);

            PrintResults.Print(results);
        }
    }
}
