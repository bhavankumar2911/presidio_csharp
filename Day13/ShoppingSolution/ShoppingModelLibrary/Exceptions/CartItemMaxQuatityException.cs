using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartItemMaxQuatityException : Exception
    {
        string message;
        public CartItemMaxQuatityException()
        {
            message = "You cannot add more than 5 of the same product";
        }
        public override string Message => message;
    }
}
