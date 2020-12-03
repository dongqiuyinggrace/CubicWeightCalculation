using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Products
{
    public class Product
    {
        public string Category { get; set; }
        public string Title { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal Weight { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Size Size { get; set; }
    }
}
