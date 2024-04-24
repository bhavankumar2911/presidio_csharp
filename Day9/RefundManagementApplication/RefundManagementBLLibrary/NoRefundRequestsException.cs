using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class NoRefundRequestsException : Exception
    {
        string ErrorMessage;
        public NoRefundRequestsException()
        {
            ErrorMessage = "No refund requests have been raised by the employees.";
        }
        public override string Message => ErrorMessage;
    }
}
