using System;
using System.Text.Json.Serialization;

namespace Covid19Data.Models
{
    public class DailyDataFioCruz
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod_ibge")]
        public string Code { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("new_deaths")]
        public int NewDeaths { get; set; }

        [JsonPropertyName("new_cases")]
        public int NewCases { get; set; }
    }
}