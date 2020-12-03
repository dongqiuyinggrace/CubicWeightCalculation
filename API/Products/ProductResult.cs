using System;
using System.Collections.Generic;
using System.Text;

namespace API.Products
{
    public class ProductResult
    {
        public List<Product> Objects { get; set; }
        public string Next { get; set; }
    }
}
