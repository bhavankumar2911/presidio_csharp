using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartItemDuplicationException : Exception
    {
        string message;
        public CartItemDuplicationException(int cartItemId)
        {
            message = $"Cart item with this id {cartItemId} already exists";
        }
        public override string Message => message;
    }
}
