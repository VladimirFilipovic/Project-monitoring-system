using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
            return Query.OfType<Project>()
                .Include(p => p.Demos)
                .Include(p => p.Documentation)
                .Include(p => p.EmployeeProjects)
                .Include(p => p.Payments)
                .ThenInclude(payment => payment.Client)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.EmployeeTasks)
                .Include(p => p.Request)
                .Include(p => p.Documentation).Where(p => p.Id == id)
                .SingleOrDefault();
        }

         public Project GetProjectByName(String name)
        {
            return Query.OfType<Project>()
                .Include(p => p.Demos)
                .Include(p => p.Documentation)
                .Include(p => p.EmployeeProjects)
                .Include(p => p.Payments)
                .Include(p => p.Tasks)
                .Include(p => p.Request)
                .Where(p => p.Name == name)
                .ToList()[0];
        }

        public List<Project> GetProjects()
        {
            return Query.OfType<Project>()
                .Include(p => p.Demos)
                .Include(p => p.Documentation)
                .Include(p => p.EmployeeProjects)
                .Include(p => p.Payments)
                .Include(p => p.Tasks)
                .Include(p => p.Request)
                .ToList();
        }

        public void InsertProject(Project Project)
        {
            Insert(Project);
        }

        public void UpdateUser(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
