using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        string message;
        public CustomerNotFoundException(int customerId)
        {
            message = $"No customer is found with this id: {customerId}";
        }
        public override string Message => message;
    }
}
