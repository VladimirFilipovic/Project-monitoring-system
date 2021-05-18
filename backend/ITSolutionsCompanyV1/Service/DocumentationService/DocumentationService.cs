using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Repositories.DocumentationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.DocumentationService
{
    public class DocumentationService : IDocumentationService
    {
        private DocumentationRepository _documentationRepository;
        public DocumentationService(DocumentationRepository documentationRepository)
        {
            _documentationRepository = documentationRepository;
        }
        public void DeleteDocumentation(Documentation Documentation)
        {
            throw new NotImplementedException();
        }

        public List<Documentation> GetDocumentation()
        {
            throw new NotImplementedException();
        }

        public Documentation GetDocumentationById(Guid id)
        {
            return _documentationRepository.GetDocumentationById(id);
        }

        public void UpdateDocumentation(Documentation Documentation)
        {
            throw new NotImplementedException();
        }
    }
}
