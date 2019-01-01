using System;

namespace MichalBialecki.com.TestingExamples.Web.Product
{
    public class ProductService : IProductService
    {
        public string SaveProduct(ProductDto product)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
