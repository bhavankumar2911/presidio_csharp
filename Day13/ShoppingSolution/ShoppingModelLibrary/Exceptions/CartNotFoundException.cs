using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartNotFoundException : Exception
    {
        string message;
        public CartNotFoundException(int cartId)
        {
            message = $"No cart is found with this id: {cartId}";
        }
        public override string Message => message;
    }
}
