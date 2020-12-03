using NUnit.Framework;
using API.Products;

namespace API.UnitTests
{
    [TestFixture]
    public class ProductSizeTests
    {
        private Size _size;

        [SetUp]
        public void Setup()
        {
            _size = new Size();
        }

        [Test]
        [TestCase(1,1,1,0.000001)]
        [TestCase(40,20,30,0.024)]
        [TestCase(26.0,26.0,5.0, 0.00338)]
        public void GetVolumeInM_WhenCalled_ReturnProductOfThreeDimension(decimal w, decimal h, decimal l, decimal expectedResult)
        {
            _size.Width = w;
            _size.Height = h;
            _size.Length = l;

            var volume = _size.GetVolumeInM();

            Assert.That(volume, Is.EqualTo(expectedResult));
        }
    }
}