using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartItemNotFoundException : Exception
    {
        string message;
        public CartItemNotFoundException(int cartId)
        {
            message = $"No cart item is found with this id: {cartId}";
        }
        public override string Message => message;
    }
}
