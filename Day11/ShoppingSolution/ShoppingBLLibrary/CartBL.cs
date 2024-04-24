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
    public class CartBL:ICartService
    {
        readonly IRepository<int, Cart> _cartRepository;
        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public Cart AddCartItemToCart(int cartId, CartItem cartItem)
        {
            Cart cart = _cartRepository.GetByKey(cartId);

            if (cart != null)
            {
                cart.CartItems.Add(cartItem);
                return cart;
            }

            throw new CartNotFoundException(cartId);

        }
    }
}
