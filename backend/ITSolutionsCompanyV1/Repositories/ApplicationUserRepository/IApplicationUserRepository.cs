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
        List<ApplicationUser> GetUsers();
        List<Client> GetClients();
        List<Employee> GetEmployees();
        //void AddClient(Client client);
        void InsertEmployee(Employee employee);
        // void UpdateClient(Client client);
        // void UpdateEmployee(Employee employee);
        void UpdateUser(ApplicationUser user);
        void DeleteUser(ApplicationUser user);        
    }
}
