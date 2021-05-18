using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.DocumentationRepository
{
    public class DocumentationRepository : Repository<Documentation>, IDocumentationRepository
    {
        public DocumentationRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
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
            return Query.OfType<Documentation>()
                .Where(d => d.Id == id)
                .Include(d => d.Project).ToList()[0];
        }

        public void UpdateDocumentation(Documentation Documentation)
        {
            throw new NotImplementedException();
        }
    }
}
