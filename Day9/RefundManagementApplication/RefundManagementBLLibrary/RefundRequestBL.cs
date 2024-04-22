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
        public RefundRequest RaiseRefundRequest(RefundRequest refundRequest)
        {
            return _refundRequestsRepository.Add(refundRequest);
        }

        public List<RefundRequest> GetAllRefundRequests()
        {
            return _refundRequestsRepository.GetAll();
        }
    }
}
