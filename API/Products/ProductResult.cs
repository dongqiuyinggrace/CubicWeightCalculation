using System.Collections.Generic;

namespace API.Products
{
    public class ProductResult
    {
        public List<Product> Objects { get; set; }
        public string Next { get; set; }
    }
}
