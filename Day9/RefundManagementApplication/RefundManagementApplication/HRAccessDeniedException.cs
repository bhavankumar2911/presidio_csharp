using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementApplication
{
    internal class HRAccessDeniedException : Exception
    {
        string ErrorMessage;
        public HRAccessDeniedException()
        {
            ErrorMessage = "You have entered wrong credentials!";
        }
        public override string Message => ErrorMessage;
    }
}
