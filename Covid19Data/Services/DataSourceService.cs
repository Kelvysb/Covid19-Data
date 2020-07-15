using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Covid19Data.Models;

namespace Covid19Data.Services
{
    public class DataSourceService : IDataSourceService
    {
        public async Task<CovidDataFioCruz> getFioCruzData()
        {
            CovidDataFioCruz result = new CovidDataFioCruz();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                string baseURL = "https://bigdata-api.fiocruz.br/numero/casos/pais/Brasil";

                HttpResponseMessage response = await client.GetAsync(baseURL);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<CovidDataFioCruz>(content);
            }

            return result;
        }

        public async Task<CovidDataWorld> getWorldData()
        {
            CovidDataWorld result = new CovidDataWorld();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                string baseURL = "https://api.apify.com/v2/key-value-stores/tVaYRsPHLjNdNBu7S/records/LATEST?disableRedirect=true";

                HttpResponseMessage response = await client.GetAsync(baseURL);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                result.CountryData = JsonSerializer.Deserialize<List<CountryData>>(content);

                result.TotalCases = result.CountryData.Sum(country => country.Infected);
                result.TotalDeaths = result.CountryData.Sum(country => country.Deceased);
                result.CountryData = result.CountryData.OrderByDescending(country => country.Deceased).ToList();
            }

            return result;
        }
    }
}