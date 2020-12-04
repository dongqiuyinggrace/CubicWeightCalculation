using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Products
{
    public class CubicWeightCalculator
    {
        private const string FIRST_PAGE_URL = "/api/products/1";
        private readonly IProductInfoGetter _productInfoGetter;
        private List<Product> products = new List<Product>();

        public CubicWeightCalculator(IProductInfoGetter productInfoGetter)
        {
            _productInfoGetter = productInfoGetter;
        }

        public async Task<decimal> CalculateAverageCubicWeightAsync()
        {
            var productUrl = FIRST_PAGE_URL;   
            while (productUrl != null)
            {
                var productResult = await _productInfoGetter.GetProductResultAsync(productUrl);
                GetProductsInEachPage(productResult);
                productUrl = productResult.Next;
            }
            return GetAverageCubicWeight();
        }

        private void GetProductsInEachPage(ProductResult productResult)
        {
            if (productResult.Objects == null)
            {
                return;
            }

            foreach (var product in productResult.Objects)
            {
                if (product.IsAirConditioner() && product.Size != null)
                {
                   products.Add(product);
                }
            }
        }

        private decimal GetAverageCubicWeight()
        {
            if (products.Count == 0)
            {
                return 0;
            }

            return products.Sum(pt => pt.GetCubicWeight()) / products.Count;
        }
    }
}