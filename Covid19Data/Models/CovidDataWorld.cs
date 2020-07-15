using System.Collections.Generic;

namespace Covid19Data.Models
{
    public class CovidDataWorld
    {
        public int TotalDeaths { get; set; }

        public int TotalCases { get; set; }

        public List<CountryData> CountryData { get; set; }
    }
}