using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartsFoundException : Exception
    {
        string message;
        public NoCartsFoundException()
        {
            message = "No carts are available";
        }
        public override string Message => message;
    }

}
