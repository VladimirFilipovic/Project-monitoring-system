using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.ApplicationUserRepository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUserById(Guid id);
        Employee GetEmployeeById(Guid id);
        Client GetClientById(Guid id);
        List<ApplicationUser> GetUsers();
        List<Client> GetClients();
        List<Employee> GetEmployees();
        void InsertEmployee(Employee employee);
        void UpdateUser(ApplicationUser user);
        Employee DeleteEmployee(Guid id);   
        Client DeleteClient (Guid id);
    }
}
