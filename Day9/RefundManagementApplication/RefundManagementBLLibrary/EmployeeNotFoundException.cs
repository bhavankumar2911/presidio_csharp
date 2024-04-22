using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class EmployeeNotFoundException : Exception
    {
        string ErrorMessage;
        public EmployeeNotFoundException()
        {
            ErrorMessage = "No employee with this email address exist!";
        }
        public override string Message => ErrorMessage;
    }
}
