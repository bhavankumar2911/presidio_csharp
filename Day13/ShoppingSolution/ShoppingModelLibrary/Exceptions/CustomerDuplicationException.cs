using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CustomerDuplicationException : Exception
    {
        string message;
        public CustomerDuplicationException(int customerId)
        {
            message = $"Customer with this id {customerId} already exists";
        }
        public override string Message => message;
    }
}
