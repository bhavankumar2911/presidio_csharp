using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTest
{
    public class Tests
    {
        IRepository<int, Product> _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            Product newProduct = new Product(1, 100000, "Laptop", 13);
            _productRepository.Add(newProduct);
        }

        [Test]
        public void AddProductPassTest()
        {
            Product newProduct = new Product(2, 100000, "Laptop", 13);
            _productRepository.Add(newProduct);
            List<Product> products = (List<Product>)_productRepository.GetAll();
            Assert.AreEqual(2, products.Count);
        }

        [Test]
        public void AddProductExceptionTest()
        {
            Product newProduct = new Product(1, 100000, "Laptop", 13);
            var exception = Assert.Throws<ProductDuplicationException>(() => _productRepository.Add(newProduct));

            Assert.AreEqual($"Product with this id {newProduct.Id} already exists", exception.Message);
        }

        [Test]
        public void GetProductByIdPassTest()
        {
            Product product = _productRepository.GetByKey(1);
            Assert.AreEqual("Laptop", product.Name);
        }

        [Test]
        public void GetProductByIdExceptionTest()
        {
            var exception = Assert.Throws<ProductNotFoundException>(() => _productRepository.GetByKey(5));

            Assert.AreEqual($"No product is found with this id: {5}", exception.Message);
        }

        [Test]
        public void GetAllProductsPassTest()
        {

        }
    }
}