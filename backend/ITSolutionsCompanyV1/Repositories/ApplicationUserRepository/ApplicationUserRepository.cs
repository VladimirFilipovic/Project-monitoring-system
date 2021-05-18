using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITSolutionsCompanyV1.Repositories.ApplicationUserRepository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }

        public void InsertEmployee(Employee employee)
        {
            Insert(employee);
        }

        public void AddUser(ApplicationUser user)
        {
            Insert(user);
        }

        public void DeleteUser(ApplicationUser user)
        {
            Delete(user);
        }

        public List<Client> GetClients()
        {
            return Query.OfType<Client>().ToList();
        }

        public List<Employee> GetEmployees()
        {
            return Query.OfType<Employee>()
                .Include(e => e.EmployeeTasks)
                .Include(e => e.EmployeeProjects)
                .Include(e => e.Documentation)
                .ToList();
        }
        public ApplicationUser GetUserById(Guid id)
        {
            return FindById(id);
        }

        public Employee GetEmployeeById(Guid id) 
        {
            return Query.OfType<Employee>()
                .Where(e => e.Id == id)
               .Include(e => e.EmployeeTasks)
               .Include(e => e.EmployeeProjects)
               .Include(e => e.Documentation)
               .ToList()[0];
        }

        public List<ApplicationUser> GetUsers()
        {
            return FindAll();
        }

        public void UpdateUser(ApplicationUser user)
        {
            Update(user);
        }
    }
}
