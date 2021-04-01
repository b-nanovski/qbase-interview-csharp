using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend
{
    interface IStatService
    {
        Task<List<Tuple<string, int>>> GetCountryPopulationsAsync();
    }
}
