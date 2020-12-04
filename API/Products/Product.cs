using Newtonsoft.Json;

namespace API.Products
{
    public class Product
    {
        private const int CONVERSION_FACTOR = 250;
        public string Category { get; set; }
        public string Title { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal Weight { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Size Size { get; set; }

        public decimal GetCubicWeight()
        {
            return Size.GetVolume() * CONVERSION_FACTOR;
        }

        public bool IsAirConditioner()
        {
            return Category == "Air Conditioners";
        }
    }
}
