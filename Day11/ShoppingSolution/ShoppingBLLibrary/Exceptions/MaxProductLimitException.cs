using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class MaxProductLimitException : Exception
    {
        string message;
        public MaxProductLimitException()
        {
            message = "You can order only upto 5 units of the same product";
        }
        public override string Message => message;
    }
}
