using System;

namespace MichalBialecki.com.TestingExamples.ProductsProvider.Tests
{
    public class ProductProvider
    {
        private readonly IProductNameProvider _productNameProvider;

        public ProductProvider(IProductNameProvider productNameProvider)
        {
            _productNameProvider = productNameProvider;
        }

        public string GetProductName(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return _productNameProvider.GetProductName(id.ToString());
        }
    }
}
