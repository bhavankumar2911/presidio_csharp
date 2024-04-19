using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    internal class DepartmentsNotAvailableException: Exception
    {
        string msg;
        public DepartmentsNotAvailableException()
        {
            msg = "Department list is empty!";
        }
        public override string Message => msg;
    }
}
