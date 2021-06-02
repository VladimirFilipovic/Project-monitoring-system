using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.ProjectsService
{
    public interface IProjectsService
    {
        public List<Project> GetAllProjects();
        public void UpdateProject(Guid id, Project Project);
        public void InsertProject(Project Project);
        public Project DeleteProject(Guid id);
        public Project GetByName(String name);
    }
}
