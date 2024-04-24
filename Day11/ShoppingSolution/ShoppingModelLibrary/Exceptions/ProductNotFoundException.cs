using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        string message;
        public ProductNotFoundException(int productId)
        {
            message = $"No product is found with this id: {productId}";
        }
        public override string Message => message;
    }
}
