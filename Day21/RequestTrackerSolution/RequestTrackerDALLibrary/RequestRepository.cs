using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    internal class RequestRepository : IRepository<int, Request>
    {
        public Task<Request> Add(Request entity)
        {
            throw new NotImplementedException();
        }

        public Task<Request> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Request> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Request>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Request> Update(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
