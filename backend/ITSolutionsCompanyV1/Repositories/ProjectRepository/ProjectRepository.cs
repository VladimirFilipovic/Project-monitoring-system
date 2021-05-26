using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.ProjectRepository
{
    public class ProjectRepository: Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }

        public Project DeleteProject(Guid id)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetProjects()
        {
            throw new NotImplementedException();
        }

        public void InsertProject(Project Project)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
