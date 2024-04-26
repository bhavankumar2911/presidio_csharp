using ShoppingBLLibrary.Exceptions;
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
    public enum QuantityUpdateType
    {
        Increase,
        Decrease
    }

    public class CartItemBL
    {
        readonly IRepository<int, CartItem> _cartItemRepository;
        readonly IRepository<int, Cart> _cartRepository;
        readonly IRepository<int, Product> _productRepository;

        public CartItemBL(IRepository<int, CartItem> cartItemRepository, IRepository<int, Cart> cartRepository, IRepository<int, Product> productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        private int GenerateId ()
        {
            int maxId = Int32.MinValue;
            List<Cart> cart = (List<Cart>)_cartItemRepository.GetAll();

            foreach (var cartItem in cart)
            {
                maxId = Math.Max(maxId, cartItem.Id);
            }

            return ++maxId;
        }

        public CartItem CreateCartItem(Product product, int cartId)
        {
            CartItem cartItem = new CartItem(GenerateId(), product, cartId);
            return cartItem;
        }

        public CartItem UpdateCartItemQuantity (int cartId, int cartItemId, QuantityUpdateType quantityUpdateType)
        {
            Cart cart = _cartRepository.GetByKey(cartId);

            CartItem cartItem = _cartItemRepository.GetByKey(cartItemId);
            Product product = _productRepository.GetByKey(cartItem.ProductId);
            CartItem cartItemToBeUpdated = cart.CartItems.Find(currentCartItem => currentCartItem.Id == cartItemId);

            if (quantityUpdateType == QuantityUpdateType.Increase)
            {
                if (cartItem.Quantity == 5) throw new MaxProductLimitException();

                cartItem.Quantity++;
                cartItemToBeUpdated.Quantity++;
                product.QuantityInHand--;

                
            } else
            {
                if (cartItem.Quantity == 1)
                {
                    _cartItemRepository.Delete(cartItem.Id);
                    cart.CartItems.Remove(cartItem);
                }

                cartItem.Quantity--;
                cartItemToBeUpdated.Quantity--;
                product.QuantityInHand++;
            }

            _cartItemRepository.Update(cartItem);
            _productRepository.Update(product);
            _cartRepository.Update(cart);

            return cartItem;
        }

        public CartItem DeleteCartItem (int cartItemId)
        {
            CartItem cartItem = _cartItemRepository.Delete(cartItemId); 

            Cart cart = _cartRepository.GetByKey(cartItem.CartId);

            cart.CartItems.Remove(cartItem);

            _cartRepository.Update(cart);

            Product product = _productRepository.GetByKey(cartItem.ProductId);

            product.QuantityInHand += cartItem.Quantity;

            _productRepository.Update(product);

            return cartItem ;
        }
    }
}
