using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {

        public Task<IList<Request>> ViewAllRequests(Employee employee);

        public Task<IList<Request>> ViewAllRequests();

        public Task RaiseRequest(Request request, int employeeID);
    }
}
