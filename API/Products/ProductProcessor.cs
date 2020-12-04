using System.Threading.Tasks;

namespace API.Products
{
    public class ProductProcessor : IProductProcessor
    {
        private readonly IProductInfoGetter _productInfoGetter;

        public ProductProcessor(IProductInfoGetter productInfoGetter)
        {
            _productInfoGetter = productInfoGetter;
        }
        public async Task<decimal> CalcAveCubicWeightAsync()
        {   
            var calculator = new CubicWeightCalculator(_productInfoGetter);
            return await calculator.CalculateAverageCubicWeightAsync();
        }
    }
}