using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementModelLibrary
{
    public enum RequestStatus
    {
        Waiting,
        Approved,
        Rejected
    }

    public enum RequestType
    {
        Education,
        Medical,
        Travel,
        WorkSuppliesAndTools,
        Miscellaneous
    }

    public class RefundRequest
    {
        public int Id { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public RequestType RequestType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Employee RaisedBy { get; set; }
        public string RejectionReason { get; set; }

        public RefundRequest(RequestType requestType, double amount, Employee raisedBy)
        {
            RequestType = requestType;
            Date = DateTime.Today;
            Amount = amount;
            RaisedBy = raisedBy;
            RequestStatus = RequestStatus.Waiting;
            RejectionReason = "";
        }
    }
}
