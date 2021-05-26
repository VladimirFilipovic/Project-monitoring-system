using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Repositories.RequestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.RequestsService
{
    public class RequestsService: IRequestsService
    {
        private RequestRepository _requestRepository;
        public RequestsService(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Request DeleteRequest(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAllRequests()
        {
            return _requestRepository.GetRequests();
        }

        public void InsertRequest(Request request)
        {
            throw new NotImplementedException();
        }

        public void UpdateRequest(Guid id, Request request)
        {
            throw new NotImplementedException();
        }
    }
}
