using API.Products;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.UnitTests
{
    [TestFixture]
    public class CubicWeightCalculatorTests
    {
        [Test]
        public async Task CalculateAveCubicWeight_WhenCalled_GetAverageCubicWeight()
        {
            var productInfoGetter = new FakeProductInfoGetter();
            var caculator = new CubicWeightCalculator(productInfoGetter);
            var result = await caculator.CalculateAveCubicWeight();
            System.Console.WriteLine(result);
            Assert.That(result, Is.EqualTo(8));
        }
    }
}