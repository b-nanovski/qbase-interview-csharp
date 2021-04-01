using Backend.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class SqliteDbManager : IDbManager
    {
        public SqliteDbContext SqliteDbContextInstance { get; }

        public SqliteDbManager() => this.SqliteDbContextInstance = new SqliteDbContext();

        private SQLiteConnection SimpleDbConnection() => new SQLiteConnection("Data Source=citystatecountry.db");

        private List<Tuple<string, int>> GetCountryPopulations()
        {
            var result = new List<Tuple<string, int>>();

            try
            {
                using (this.SqliteDbContextInstance)
                {
                    var countries = this.SqliteDbContextInstance.Country.ToList();

                    foreach (Country country in countries)
                    {
                        int population = 0;
                        foreach (State state in country.States)
                        {
                            using (SQLiteConnection cnn = this.SimpleDbConnection())
                            {
                                cnn.Open();
                                string sql = "select * from City where Population is not null and StateId = " + state.StateId;

                                using (SqlMapper.GridReader multi = cnn.QueryMultiple(sql))
                                {
                                    var cities = multi.Read<City>().ToList();
                                    foreach (City city in cities)
                                    {
                                        population += city.Population.Value;
                                    }
                                }
                                cnn.Close();
                            }
                        }

                        result.Add(
                            Tuple.Create(country.CountryName, population)
                            );
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Tuple<string, int>>();
            }
        }

        public Task<List<Tuple<string, int>>> GetCountryPopulationsAsync() => Task.FromResult(this.GetCountryPopulations());
    }
}
