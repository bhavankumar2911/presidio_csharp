using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTest
{
    public class CartRepositoryTest
    {
        IRepository<int, Cart> _cartRepository;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            Cart newCart = new Cart(1, 1);
            _cartRepository.Add(newCart);
        }

        [Test]
        public void AddCartPassTest()
        {
            Cart newCart = new Cart(2, 2);
            _cartRepository.Add(newCart);
            List<Cart> carts = (List<Cart>)_cartRepository.GetAll();
            Assert.AreEqual(2, carts.Count);
        }

        [Test]
        public void AddCartExceptionTest()
        {
            Cart newCart = new Cart(1, 1);
            var exception = Assert.Throws<CartDuplicationException>(() => _cartRepository.Add(newCart));

            Assert.AreEqual($"Cart with this id {newCart.Id} already exists", exception.Message);
        }

        [Test]
        public void GetCartByIdPassTest()
        {
            Cart cart = _cartRepository.GetByKey(1);
            Assert.AreEqual(1, cart.CustomerId);
        }

        [Test]
        public void GetCartByIdExceptionTest()
        {
            var exception = Assert.Throws<CartNotFoundException>(() => _cartRepository.GetByKey(5));

            Assert.AreEqual($"No cart is found with this id: {5}", exception.Message);
        }

        [Test]
        public void GetAllCartsPassTest()
        {
            List<Cart> carts = (List<Cart>)_cartRepository.GetAll();
            Assert.AreEqual(1, carts.Count);
        }

        [Test]
        public void GetAllCartsExceptionTest()
        {
            IRepository<int, Cart> _cartRepository = new CartRepository();

            var exception = Assert.Throws<NoCartsFoundException>(() => _cartRepository.GetAll());

            Assert.AreEqual("No carts are available", exception.Message);
        }

        [Test]
        public void DeleteCartPassTest()
        {
            Cart newCart = new Cart(2, 2);
            _cartRepository.Add(newCart);
            Cart deletedCart = _cartRepository.Delete(1);

            Assert.AreEqual(1, _cartRepository.GetAll().Count);
        }

        [Test]
        public void DeleteCartExceptionTest()
        {
            var exception = Assert.Throws<CartNotFoundException>(() => _cartRepository.Delete(5));

            Assert.AreEqual("No cart is found with this id: 5", exception.Message);
        }

        [Test]
        public void CartUpdatePassTest()
        {
            Cart cartWithChanges = new Cart(1, 2);
            _cartRepository.Update(cartWithChanges);

            Cart updatedCart = _cartRepository.GetByKey(1);

            Assert.AreEqual(2, updatedCart.CustomerId);
        }

        [Test]
        public void CartUpdateExceptionTest()
        {
            Cart cartWithChanges = new Cart(5, 1);

            var exception = Assert.Throws<CartNotFoundException>(() => _cartRepository.Update(cartWithChanges));

            Assert.AreEqual("No cart is found with this id: 5", exception.Message);
        }
    }
}
