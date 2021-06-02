using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.RequestRepository
{
    public interface IRequestRepository
    {
        List<Request> GetRequests();
        Request GetRequestById(Guid id);
        void InsertRequest(Request request);
        void UpdateRequest(Request request);
        Request DeleteRequest(Guid id);
    }
}
