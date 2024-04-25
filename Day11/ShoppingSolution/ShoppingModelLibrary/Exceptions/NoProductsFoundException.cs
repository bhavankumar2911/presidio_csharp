using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoProductsFoundException : Exception
    {
        string message;
        public NoProductsFoundException()
        {
            message = "No products are available";
        }
        public override string Message => message;
    }
}
