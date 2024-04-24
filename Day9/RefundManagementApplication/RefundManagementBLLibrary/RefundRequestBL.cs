using RefundManagementDALLibrary;
using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class RefundRequestBL : IRefundRequestService
    {
        readonly IRepository<int, RefundRequest> _refundRequestsRepository;

        public RefundRequestBL()
        {
            _refundRequestsRepository = new RefundRequestRepository();
        }
        public void RaiseRefundRequest(RefundRequest refundRequest)
        {
            _refundRequestsRepository.Add(refundRequest);
        }

        public List<RefundRequest> GetAllRefundRequests()
        {
            List<RefundRequest> refundRequests = _refundRequestsRepository.GetAll();

            if (refundRequests == null || refundRequests.Count == 0) throw new NoRefundRequestsException();

            return _refundRequestsRepository.GetAll();
        }

        public RefundRequest GetOneRefundRequestById(int requestId)
        {
            RefundRequest? refundRequest = _refundRequestsRepository.Get(requestId);

            if (refundRequest == null) throw new RequestNotFoundException();

            return refundRequest;
        }

        public void UpdateRefundRequestStatus(RefundRequest oldRefundRequest, RequestStatus requestStatus)
        {
            oldRefundRequest.RequestStatus = requestStatus;

            RefundRequest? updatedRequest = _refundRequestsRepository.Update(oldRefundRequest);

            if (updatedRequest == null)
            {
                throw new RequestNotFoundException();
            }
        }

        public List<RefundRequest> GetAllRefundRequestsOfAUser(int employeeId)
        {
            List<RefundRequest> requestsOfTheUser = new List<RefundRequest>();
            List<RefundRequest> allRequests
                = _refundRequestsRepository.GetAll();

            if (allRequests == null || allRequests.Count == 0) throw new NoRefundRequestsException();

            foreach (var request in allRequests)
            {
                if (request.RaisedBy.Id == employeeId) requestsOfTheUser.Add(request);
            }

            if (requestsOfTheUser.Count == 0)
                throw new NoRefundRequestsException();

            return requestsOfTheUser;
        }
    }
}
