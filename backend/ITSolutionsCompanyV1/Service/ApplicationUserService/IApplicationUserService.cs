using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.ApplicationUserService
{
    public interface IApplicationUserService
    {
        public List<ApplicationUser> GetAllUsers();
        public List<Client> GetAllClients();
        public List<Employee> GetAllEmployees();
        public Employee GetEmployee(Guid id);
        public void UpdateEmployee(Guid id, Employee employee);
        public void InsertEmployee(Employee employee);
    }
}
