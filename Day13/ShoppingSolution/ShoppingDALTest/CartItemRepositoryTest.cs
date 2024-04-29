using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTest
{
    public class CartItemRepositoryTest
    {
        IRepository<int, CartItem> _cartItemRepository;
        IRepository<int, Cart> _cartRepository;
        IRepository<int, Customer> _customerRepository;
        Cart cart;

        [SetUp]
        public void Setup()
        {
            _cartItemRepository = new CartItemRepository();
            Product product = new Product(1, 100000, "Laptop", 13);

            _customerRepository = new CustomerRepository();
            Customer customer = new Customer(1, "+91 9090909090", "bhavan", 21);
            _customerRepository.Add(customer);

            _cartRepository = new CartRepository();
            cart = new Cart(1, customer.Id);
            _cartRepository.Add(cart);

            CartItem newCartItem = new CartItem(1, product, cart.Id);
            _cartItemRepository.Add(newCartItem);
        }

        [Test]
        public void AddCartItemPassTest()
        {
            Product product = new Product(2, 20000, "Mobile", 45);
            CartItem newCartItem = new CartItem(2, product, cart.Id);
            _cartItemRepository.Add(newCartItem);
            List<CartItem> cartItems = (List<CartItem>)_cartItemRepository.GetAll();
            Assert.AreEqual(2, cartItems.Count);
        }

        [Test]
        public void AddCartItemExceptionTest()
        {
            Product product = new Product(1, 100000, "Laptop", 13);
            CartItem newCartItem = new CartItem(1, product, cart.Id);
            var exception = Assert.Throws<CartItemDuplicationException>(() => _cartItemRepository.Add(newCartItem));

            Assert.AreEqual($"Cart item with this id {newCartItem.Id} already exists", exception.Message);
        }

        [Test]
        public void GetCartItemByIdPassTest()
        {
            CartItem cartItem = _cartItemRepository.GetByKey(1);
            Assert.AreEqual("Laptop", cartItem.Product.Name);
        }

        [Test]
        public void GetCartItemByIdExceptionTest()
        {
            var exception = Assert.Throws<CartItemNotFoundException>(() => _cartItemRepository.GetByKey(5));

            Assert.AreEqual($"No cart item is found with this id: {5}", exception.Message);
        }

        [Test]
        public void GetAllCartItemsPassTest()
        {
            List<CartItem> cartItems = (List<CartItem>)_cartItemRepository.GetAll();
            Assert.AreEqual(1, cartItems.Count);
        }

        [Test]
        public void GetAllCartItemsExceptionTest()
        {
            IRepository<int, CartItem> _cartItemRepository = new CartItemRepository();

            var exception = Assert.Throws<NoCartItemsFoundException>(() => _cartItemRepository.GetAll());

            Assert.AreEqual("No cart items are available", exception.Message);
        }

        [Test]
        public void DeleteCartItemPassTest()
        {
            Product product = new Product(2, 20000, "Mobile", 45);
            CartItem newCartItem = new CartItem(2, product, cart.Id);
            _cartItemRepository.Add(newCartItem);
            CartItem deletedCartItem = _cartItemRepository.Delete(1);

            Assert.AreEqual(1, _cartItemRepository.GetAll().Count);
        }

        [Test]
        public void DeleteCartItemExceptionTest()
        {
            var exception = Assert.Throws<CartItemNotFoundException>(() => _cartItemRepository.Delete(5));

            Assert.AreEqual("No cart item is found with this id: 5", exception.Message);
        }

        [Test]
        public void CartItemUpdatePassTest()
        {
            Product product = new Product(1, 100000, "Laptop", 13);
            CartItem cartItemWithChanges = new CartItem(1, product, cart.Id);
            cartItemWithChanges.Quantity++;
            _cartItemRepository.Update(cartItemWithChanges);

            CartItem updatedCartItem = _cartItemRepository.GetByKey(1);

            Assert.AreEqual(2, updatedCartItem.Quantity);
        }

        [Test]
        public void CartItemUpdateExceptionTest()
        {
            Product product = new Product(1, 100000, "Laptop", 13);
            CartItem cartItemWithChanges = new CartItem(5, product, cart.Id);

            var exception = Assert.Throws<CartItemNotFoundException>(() => _cartItemRepository.Update(cartItemWithChanges));

            Assert.AreEqual("No cart item is found with this id: 5", exception.Message);
        }
    }
}
