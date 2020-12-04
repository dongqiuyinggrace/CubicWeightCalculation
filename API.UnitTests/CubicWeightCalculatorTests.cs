using API.Products;
using Moq;
using NUnit.Framework;
using System;
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
            var productInfoGetter = new Mock<IProductInfoGetter>();
            productInfoGetter.Setup(pg => pg.GetProductResultAsync(It.IsAny<string>())).ReturnsAsync(SetProductResult());
            var caculator = new CubicWeightCalculator(productInfoGetter.Object);

            var result = await caculator.CalculateAverageCubicWeightAsync();

            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public async Task CalculateAveCubicWeight_WhenThereIsNoProductResult_ReturnZero()
        {
            var productInfoGetter = new Mock<IProductInfoGetter>();
            var productResult = new ProductResult();
            productInfoGetter.Setup(pg => pg.GetProductResultAsync(It.IsAny<string>())).ReturnsAsync(productResult);
            var caculator = new CubicWeightCalculator(productInfoGetter.Object);

            var result = await caculator.CalculateAverageCubicWeightAsync();
            
            Assert.That(result, Is.EqualTo(0));
        }

        private ProductResult SetProductResult()
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

            return productResult;
        }
    }
}