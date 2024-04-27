using ShoppingBLLibrary;
using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class ProductBLTest
    {
        IRepository<int, Product> _productRepository;
        ProductBL productService;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            productService = new ProductBL(_productRepository);

            Product zeroQuantityProduct = new Product(1, 10000, "mobile", 0);
            _productRepository.Add(zeroQuantityProduct);
        }

        [Test]
        public void CheckAndUpdateProductBeforeAddingToCartNotFoundExceptionTest()
        {
            Exception exception = Assert.Throws<ProductNotFoundException>(() => productService.CheckAndUpdateProductBeforeAddingToCart(5));

            Assert.AreEqual("No product is found with this id: 5", exception.Message);
        }

        [Test]
        public void CheckAndUpdateProductBeforeAddingToCartOutOfStockExceptionTest()
        {
            Exception exception = Assert.Throws<ProductOutOfStockException>(() => productService.CheckAndUpdateProductBeforeAddingToCart(1));

            Assert.AreEqual("mobile is out of stock currently!", exception.Message);
        }

        [Test]
        public void CheckAndUpdateProductBeforeAddingToCartPassTest()
        {
            Product newProduct = new Product(2, 100000, "laptop", 5);
            _productRepository.Add(newProduct);

            Product updatedProduct = productService.CheckAndUpdateProductBeforeAddingToCart(2);

            Assert.AreEqual(4, updatedProduct.QuantityInHand);
        }
    }
}
