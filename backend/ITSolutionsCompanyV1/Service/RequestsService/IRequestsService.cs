using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.RequestsService
{
    public interface IRequestsService
    {
        public List<Request> GetAllRequests();
        public void UpdateRequest(Guid id, Request request);
        public void InsertRequest(Request request);
        public Request DeleteRequest(Guid id);
    }
}
