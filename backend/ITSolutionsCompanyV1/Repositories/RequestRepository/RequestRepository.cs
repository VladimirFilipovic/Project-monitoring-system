using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.RequestRepository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {   
        public RequestRepository (ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {
        }
        public Request DeleteRequest(Guid id)
        {
            throw new NotImplementedException();
        }

        public Request GetRequestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetRequests()
        {
            return GetRequests();
        }

        public void InsertRequest(Request request)
        {
            throw new NotImplementedException();
        }

        public void UpdateRequest(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
