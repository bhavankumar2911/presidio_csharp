using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class ProductOutOfStockException : Exception
    {
        string message;
        public ProductOutOfStockException(string productName)
        {
            message = $"{productName} is out of stock currently!";
        }
        public override string Message => message;
    }
}
