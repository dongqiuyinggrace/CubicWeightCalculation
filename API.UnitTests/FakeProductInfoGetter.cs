using System.Collections.Generic;
using System.Threading.Tasks;
using API.Products;

namespace API.UnitTests
{
    public class FakeProductInfoGetter : IProductInfoGetter
    {
        public Task<ProductResult> GetProductResult(string url)
        {
            var product1 = new Product()
            {
                Category = "Air Conditioners",
                Title = "Title1",
                Weight = 235.0m,
                Size = new Size()
                {
                    Width = 40,
                    Height = 30,
                    Length = 20
                }
            };
            var product2 = new Product()
            {
                Category = "Air Conditioners",
                Title = "Title2",
                Weight = 300.0m,
                Size = new Size()
                {
                    Width = 50,
                    Height = 40,
                    Length = 20
                }
            };
            var products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            var productResult = new ProductResult()
            {
                Objects = products,
                Next = null
            };

            return Task.FromResult(productResult);
        }
    }
}