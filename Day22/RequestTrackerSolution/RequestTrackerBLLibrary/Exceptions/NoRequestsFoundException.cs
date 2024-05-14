using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Exceptions
{
    public class NoRequestsFoundException : Exception
    {
        public NoRequestsFoundException() : base("No requests available") { }
    }
}
