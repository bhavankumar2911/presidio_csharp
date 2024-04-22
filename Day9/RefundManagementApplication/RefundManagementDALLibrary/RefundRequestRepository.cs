using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementDALLibrary
{
    public class RefundRequestRepository : IRepository<int, RefundRequest>
    {
        readonly Dictionary<int, RefundRequest> _refundRequests;

        public RefundRequestRepository()
        {
            _refundRequests = new Dictionary<int, RefundRequest>();
        }

        /// <summary>
        /// generate id for the new employee
        /// </summary>
        /// <returns>id of the new employee</returns>
        int GenerateId()
        {
            if (_refundRequests.Count == 0)
                return 1;
            int id = _refundRequests.Keys.Max();
            return ++id;
        }

        public RefundRequest Add(RefundRequest item)
        {
            int id = GenerateId();
            item.Id = id;

            _refundRequests.Add(id, item);

            return item;
        }

        public RefundRequest? Delete(int key)
        {
            if (_refundRequests.ContainsKey(key))
            {
                var refundRequest = _refundRequests[key];

                _refundRequests.Remove(key);
                return refundRequest;
            }

            return null;
        }

        public RefundRequest? Get(int key)
        {
            return _refundRequests.ContainsKey(key) ? _refundRequests[key] : null;
        }

        public List<RefundRequest>? GetAll()
        {
            //if (_refundRequests.Count == 0)
            //    return null;

            return _refundRequests.Values.ToList();
        }

        public RefundRequest? Update(RefundRequest item)
        {
            if (_refundRequests.ContainsKey(item.Id))
            {
                _refundRequests[item.Id] = item;
                return item;
            }

            return null;
        }
    }
}
