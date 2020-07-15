using System.Text.Json.Serialization;

namespace Covid19Data.Models
{
    public class CountryData
    {
        [JsonPropertyName("infected")]
        public int Infected { get; set; }

        [JsonPropertyName("deceased")]
        public int Deceased { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lastUpdatedSource")]
        public string LastUpdatedSource { get; set; }
    }
}