using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomersFoundException : Exception
    {
        string message;
        public NoCustomersFoundException()
        {
            message = "No customers are available";
        }
        public override string Message => message;
    }
}
