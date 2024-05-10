using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Exceptions
{
    public class EmployeeNotFoundException: Exception
    {
        public EmployeeNotFoundException(int employeeID) : base($"Employee with {employeeID} id not found") { }
    }
}
