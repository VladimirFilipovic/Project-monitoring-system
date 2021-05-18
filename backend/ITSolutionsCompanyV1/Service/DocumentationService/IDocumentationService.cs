using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.DocumentationService
{
    interface IDocumentationService
    {
        Documentation GetDocumentationById(Guid id);
        List<Documentation> GetDocumentation();
        void UpdateDocumentation(Documentation Documentation);
        void DeleteDocumentation(Documentation Documentation);
    }
}
