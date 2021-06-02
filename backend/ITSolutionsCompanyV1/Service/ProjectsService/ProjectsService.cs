using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Repositories.ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.ProjectsService
{
    public class ProjectsService : IProjectsService

    {
        private IProjectRepository _projectsRepository;
        public ProjectsService(IProjectRepository projectRepository)
        {
            _projectsRepository = projectRepository;
        }   
        public Project DeleteProject(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllProjects()
        {
            return _projectsRepository.GetProjects();
        }

        public Project GetByName(string name)
        {
            return _projectsRepository.GetProjectByName(name);
        }

        public void InsertProject(Project Project)
        {
            _projectsRepository.InsertProject(Project);
        }

        public void UpdateProject(Guid id, Project Project)
        {
            throw new NotImplementedException();
        }
    }
}
