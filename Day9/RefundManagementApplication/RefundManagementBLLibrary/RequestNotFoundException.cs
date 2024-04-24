using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class RequestNotFoundException : Exception
    {
        string ErrorMessage;
        public RequestNotFoundException()
        {
            ErrorMessage = "The refund request was not found";
        }
        public override string Message => ErrorMessage;
    }
}
