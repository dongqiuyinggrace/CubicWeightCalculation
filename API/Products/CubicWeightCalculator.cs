
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Products
{
    public class CubicWeightCalculator
    {
        private const int CONVERSION_FACTOR = 250;
        private const string CATEGORY_TO_CHECK = "Air Conditioners";
        private const string FIRST_PAGE_URL = "/api/products/1";
        private readonly IProductInfoGetter _productInfoGetter;
        private List<Product> products = new List<Product>();

        public CubicWeightCalculator(IProductInfoGetter productInfoGetter)
        {
            _productInfoGetter = productInfoGetter;
        }

        public async Task<decimal> CalculateAveCubicWeight()
        {
            var productUrl = FIRST_PAGE_URL;   
            while (productUrl != null)
            {
                var productResult = await _productInfoGetter.GetProductResult(productUrl);
                GetProductsInEachPage(productResult);
                productUrl = productResult.Next;
            }

            return GetAveCubicWeight();
        }

        private void GetProductsInEachPage(ProductResult productResult)
        {
            foreach (var product in productResult.Objects)
            {
                if (product.Category == CATEGORY_TO_CHECK && product.Size != null)
                {
                   products.Add(product);
                }
            }
        }

        private decimal GetAveCubicWeight()
        {
            var totalWeight = 0.0m;
            foreach(var product in products)
            {
                totalWeight += product.Size.GetVolumeInM() * CONVERSION_FACTOR;
            }

            return totalWeight / products.Count;
        }
    }
}