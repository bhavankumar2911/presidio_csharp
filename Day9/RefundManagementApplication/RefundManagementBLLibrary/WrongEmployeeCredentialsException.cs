using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class WrongEmployeeCredentialsException : Exception
    {
        string ErrorMessage;
        public WrongEmployeeCredentialsException()
        {
            ErrorMessage = "Credentials did not match!";
        }
        public override string Message => ErrorMessage;
    }
}
