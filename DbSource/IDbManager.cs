using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend
{
    public interface IDbManager
    {
        Task<List<Tuple<string, int>>> GetCountryPopulationsAsync();
    }
}
