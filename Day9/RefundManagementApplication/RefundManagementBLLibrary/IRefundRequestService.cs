using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public interface IRefundRequestService
    {
        void RaiseRefundRequest(RefundRequest refundRequest);

        List<RefundRequest> GetAllRefundRequests ();

        List<RefundRequest> GetAllRefundRequestsOfAUser (int employeeId);

        RefundRequest GetOneRefundRequestById (int requestId);

        void UpdateRefundRequestStatus(RefundRequest oldRefundRequest, RequestStatus requestType);
    }
}
