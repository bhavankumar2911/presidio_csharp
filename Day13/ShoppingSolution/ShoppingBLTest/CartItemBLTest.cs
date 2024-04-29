using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLTest
{
    public class CartItemBLTest
    {
        IRepository<int, Product> _productRepository;
        IRepository<int, Cart> _cartRepository;
        IRepository<int, Customer> _customerRepository;
        IRepository<int, CartItem> _cartItemRepository;
        CartItemBL cartItemService;
        Product newProduct;
        Cart cart;

        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            newProduct = new Product(1, 100000, "Laptop", 13);
            _productRepository.Add(newProduct);

            _customerRepository = new CustomerRepository();
            Customer customer = new Customer(1, "+91 9090909090", "bhavan", 21);
            _customerRepository.Add(customer);

            _cartRepository = new CartRepository();
            cart = new Cart(1, customer.Id);
            _cartRepository.Add(cart);  

            _cartItemRepository = new CartItemRepository();

            cartItemService = new CartItemBL(_cartItemRepository,_cartRepository,_productRepository);
        }

        [Test]
        public void GenerateCartItemIdWhenEmptyTest ()
        {
            int cartItemId = cartItemService.GenerateId();

            Assert.AreEqual(1, cartItemId);
        }

        [Test]
        public void GenerateCartItemIdWhenNotEmptyTest()
        {
            CartItem cartItem = new CartItem(1, newProduct, cart.Id);
            _cartItemRepository.Add(cartItem);

            int newCartItemId = cartItemService.GenerateId();

            Assert.AreEqual(2, newCartItemId);
        }

        [Test]
        public void CreateCartItemPassTest()
        {
            Product product = _productRepository.GetByKey(1);
            Cart cart = _cartRepository.GetByKey(1);

            CartItem cartItem = cartItemService.CreateCartItem(product, cart.Id);

            Assert.AreEqual(1, cartItem.Quantity);
        }

        //[Test]
        //public void UpdateCartItemQuantityIncreaseWithinLimitTest ()
        //{
        //    CartItem updatedCartItem = cartItemService.UpdateCartItemQuantity(cart.Id, 1, QuantityUpdateType.Increase);

        //    Assert.AreEqual(2, updatedCartItem.Quantity);
        //}
    }
}