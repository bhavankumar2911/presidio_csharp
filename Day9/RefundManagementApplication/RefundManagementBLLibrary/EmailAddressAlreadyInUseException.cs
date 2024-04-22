using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    internal class EmailAddressAlreadyInUseException : Exception
    {
        string ErrorMessage;
        public EmailAddressAlreadyInUseException()
        {
            ErrorMessage = "The email address you've provided is already used by an another employee. Try something new!";
        }
        public override string Message => ErrorMessage;
    }
}
