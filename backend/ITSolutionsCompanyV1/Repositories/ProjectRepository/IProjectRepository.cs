using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        List<Project> GetProjects();
        Project GetProjectById(Guid id);
        void InsertProject(Project Project);
        void UpdateUser(Project project);
        Project DeleteProject(Guid id);
        public Project GetProjectByName(String name);
    }
}
