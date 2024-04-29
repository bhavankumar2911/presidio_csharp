using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class ProductDuplicationException : Exception
    {
        string message;
        public ProductDuplicationException(int productId)
        {
            message = $"Product with this id {productId} already exists";
        }
        public override string Message => message;
    }
}
