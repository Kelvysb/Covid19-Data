using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Covid19Data.Models
{
    public class CovidDataFioCruz
    {
        [JsonPropertyName("total_mortes")]
        public int TotalDeaths { get; set; }

        [JsonPropertyName("total_casos")]
        public int TotalCases { get; set; }

        [JsonPropertyName("detalhes_por_dia")]
        public List<DailyDataFioCruz> DailyData { get; set; }
    }
}