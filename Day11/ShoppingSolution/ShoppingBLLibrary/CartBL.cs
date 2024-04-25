using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        readonly IRepository<int, Cart> _cartRepository;
        readonly IRepository<int, CartItem> _cartItemRepository;
        readonly IRepository<int, Product> _productRepository;
        readonly ProductBL productService;
        readonly CartItemBL cartItemService;

        public CartBL(IRepository<int, Cart> cartRepository, IRepository<int, Product> productRepository, IRepository<int, CartItem> cartItemRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            productService = new ProductBL(productRepository);
            cartItemService = new CartItemBL(cartItemRepository, cartRepository, productRepository);
        }

        private int GenerateId()
        {
            int maxId = Int32.MinValue;
            List<Cart> carts = (List<Cart>)_cartRepository.GetAll();

            foreach (var cart in carts)
            {
                maxId = Math.Max(maxId, cart.Id);
            }

            return ++maxId;
        }

        public Cart AddCartItemToCart(int productId, int cartId)
        {
            try
            {
                Product product = productService.CheckAndUpdateProductBeforeAddingToCart(productId);

                Cart cart = _cartRepository.GetByKey(cartId);

                CartItem cartItem = cartItemService.CreateCartItem(product, cartId);

                cart.CartItems.Add(cartItem);
                
                _cartRepository.Update(cart);
                _cartItemRepository.Add(cartItem);

                return cart;
            } catch (Exception)
            {
                throw;
            }
        }

        public double CalculateTotalCartAmount (int cartId)
        {
            Cart cart = _cartRepository.GetByKey (cartId);

            double cartAmount = 0;

            foreach (var cartItem in cart.CartItems)
            {
                cartAmount += (cartItem.Quantity * cartItem.Price);
            }

            return cartAmount;
        }

        public double CalulateCheckoutPrice (int cartId)
        {
            Cart cart = _cartRepository.GetByKey(cartId);
            double totalCartAmount = CalculateTotalCartAmount(cartId);

            if ((cart.CartItems.Count <= 3) && (totalCartAmount >= 1500))
                return 0.05 * totalCartAmount;

            return totalCartAmount;
        }
    }
}
