using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    internal interface ICartService
    {
        Cart AddCartItemToCart(int cartId, CartItem cartItem); 
    }
}
