using RequestTrackerBLLibrary.Exceptions;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        IRepository<int, Request> _repository;

        public RequestBL (RequestTrackerContext context)
        {
            _repository = new RequestRepository(context);
        }

        public Task<IList<Request>> ViewAllRequests(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Request>> ViewAllRequests()
        {
            IList<Request> requests = await _repository.GetAll();

            if (requests.Count == 0)
            {
                throw new NoRequestsFoundException();
            }

            return requests;
        }

        public async Task RaiseRequest(Request request, int employeeID)
        {
            request.RequestRaisedBy = employeeID;
            request.RequestStatus = "open";
            request.RequestClosedBy = -1;
            await _repository.Add(request);
        }
    }
}
