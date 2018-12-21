using MichalBialecki.com.TestingExamples.ProductsProvider.Tests;
using NSubstitute;
using NUnit.Framework;

namespace MichalBialecki.com.TestingExamples.ProductsProvider
{
    [TestFixture]
    public class ProductProviderTests
    {
        private IProductNameProvider productNameProvider;
        private ProductProvider productProvider;

        [SetUp]
        public void SetUp()
        {
            productNameProvider = Substitute.For<IProductNameProvider>();
            productProvider = new ProductProvider(productNameProvider);
        }

        [Test]
        public void GetProductName_GivenPositiveId_ReturnsCorrectName()
        {
            // Arrange
            var productName = "Product 1";
            productNameProvider.GetProductName("1").Returns(productName);

            // Act
            var result = productProvider.GetProductName(1);

            // Arrange
            Assert.AreEqual(productName, result);
        }
    }
}
