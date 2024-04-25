using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartItemsFoundException : Exception
    {
        string message;
        public NoCartItemsFoundException()
        {
            message = "No cart items are available";
        }
        public override string Message => message;
    }
}
