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
        RefundRequest RaiseRefundRequest(RefundRequest refundRequest);

        List<RefundRequest> GetAllRefundRequests ();
    }
}
