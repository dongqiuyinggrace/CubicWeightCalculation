using NUnit.Framework;
using API.Products;

namespace API.UnitTests
{
    [TestFixture]
    public class ProductSizeTests
    {
        [Test]
        [TestCase(1, 1, 1, 0.000001)]
        [TestCase(40, 20, 30, 0.024)]
        [TestCase(26.0, 26.0, 5.0, 0.00338)]
        public void GetVolumeInM_WhenCalled_ReturnProductOfThreeDimension(decimal weight, decimal height, decimal length, decimal expectedResult)
        {
            var size = new Size()
            {
                Width = weight,
                Height = height,
                Length = length,
            };
        
            var volume = size.GetVolume();

            Assert.That(volume, Is.EqualTo(expectedResult));
        }
    }
}