using System.Threading.Tasks;

namespace API.Products
{
    public class ProductProcessor : IProductProcessor
    {
        public async Task<decimal> CalcAveCubicWeight()
        {   
            var productInfoGetter = new ProductInfoGetter();
            var calculator = new CubicWeightCalculator(productInfoGetter);
            var result = await calculator.CalculateAveCubicWeight();
            return result;
        }
    }
}