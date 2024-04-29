using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartDuplicationException : Exception
    {
        string message;
        public CartDuplicationException(int cartId)
        {
            message = $"Cart with this id {cartId} already exists";
        }
        public override string Message => message;
    }

}
