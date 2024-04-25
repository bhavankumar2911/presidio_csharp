using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTest
{
    public class ProductRepositoryTest
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
            List<Product> products = (List<Product>)_productRepository.GetAll();
            Assert.AreEqual(1, products.Count);
        }

        [Test]
        public void GetAllProductsExceptionTest()
        {
            IRepository<int, Product> _productRepository = new ProductRepository();

            var exception = Assert.Throws<NoProductsFoundException>(() => _productRepository.GetAll());

            Assert.AreEqual("No products are available", exception.Message);
        }

        [Test]
        public void DeleteProductPassTest()
        {
            Product newProduct = new Product(2, 20000, "Mobile", 13);
            _productRepository.Add(newProduct);
            Product deletedProduct = _productRepository.Delete(1);

            Assert.AreEqual(1, _productRepository.GetAll().Count);
        }

        [Test]
        public void DeleteProductExceptionTest()
        {
            var exception = Assert.Throws<ProductNotFoundException>(() => _productRepository.Delete(5));

            Assert.AreEqual("No product is found with this id: 5", exception.Message);
        }

        [Test]
        public void ProductUpdatePassTest()
        {
            Product productWithChanges = new Product(1, 100000, "Laptop (updated)", 13);
            _productRepository.Update(productWithChanges);

            Product updatedProduct = _productRepository.GetByKey(1);

            Assert.AreEqual("Laptop (updated)", updatedProduct.Name);
        }

        [Test]
        public void ProductUpdateExceptionTest()
        {
            Product productWithChanges = new Product(5, 100000, "Laptop (updated)", 13);

            //Product updatedProduct = _productRepository.GetByKey(1);

            var exception = Assert.Throws<ProductNotFoundException>(() => _productRepository.Update(productWithChanges));

            Assert.AreEqual("No product is found with this id: 5", exception.Message);
        }
    }
}